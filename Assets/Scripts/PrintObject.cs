using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrintObject : MonoBehaviour, InteractableObj
{
    [SerializeField]
    private MeshFilter objectToPrint;

    [SerializeField, Range (0, 1)]
    private float amountToPrint;




    [SerializeField]
    private float printingSpeed = 0.01f;

    private Mesh meshToPrint;
    private float meshToPrintMax;
    private float meshToPrintMin;
    private float meshToPrintHeigth;

    private List<Vector3> usedVertices;
    private List<Vector3> verticesLeftToUse;
    private List<int> trianglesToComplete;
    private List<int> completedTriangles;
    private Dictionary<int, int> verticeIReferences;
    private List<int> leftVerticeIReferences;

    private bool finishedPrinting = true;

    [SerializeField]
    private GameObject printedObject;

    private void Start()
    {
        ResetMesh();
    }

    public void Interact(){
        StartPrinting();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!finishedPrinting) {
            float y = meshToPrint.bounds.size.y * amountToPrint;

            amountToPrint += printingSpeed;
            if (amountToPrint >= 1)
            {
                finishedPrinting = true;
            }
            Print();
        }
    }

    public void Print()
    {
        List<Vector3> vertices = usedVertices;
        List<int> triangles = completedTriangles;
        List<int> currentTriangleInRangeVertices = new List<int>();
        List<int> currentTriangleOutRangeVertices = new List<int>();

        float y = meshToPrintMin + meshToPrintHeigth * amountToPrint;

        Mesh mesh = new Mesh();

        int n = 0;

        while (n < verticesLeftToUse.Count)
        {
            if (verticesLeftToUse[n].y <= y)
            {
                vertices.Add(verticesLeftToUse[n]);
                verticeIReferences.Add(leftVerticeIReferences[n], vertices.Count - 1);
                usedVertices.Add(verticesLeftToUse[n]);
                verticesLeftToUse.Remove(verticesLeftToUse[n]);
                leftVerticeIReferences.Remove(leftVerticeIReferences[n]);
            }
            else
            {
                n++;
            }
        }

        int i = 0;
        while (i < trianglesToComplete.Count)
        {
            currentTriangleInRangeVertices.Clear();
            currentTriangleOutRangeVertices.Clear();
            for (int j = 0; j < 3; j++)
            {
                if (verticeIReferences.ContainsKey(trianglesToComplete[i + j]))
                {
                    currentTriangleInRangeVertices.Add(trianglesToComplete[i + j]);
                }
                else
                {
                    currentTriangleOutRangeVertices.Add(trianglesToComplete[i + j]);
                }
            }

            if (currentTriangleInRangeVertices.Count == 3)
            {
                completedTriangles.Add(verticeIReferences[trianglesToComplete[i]]);
                completedTriangles.Add(verticeIReferences[trianglesToComplete[i + 1]]);
                completedTriangles.Add(verticeIReferences[trianglesToComplete[i + 2]]);
                triangles.Add(verticeIReferences[trianglesToComplete[i]]);
                triangles.Add(verticeIReferences[trianglesToComplete[i + 1]]);
                triangles.Add(verticeIReferences[trianglesToComplete[i + 2]]);
                trianglesToComplete.RemoveAt(i);
                trianglesToComplete.RemoveAt(i);
                trianglesToComplete.RemoveAt(i);
            }
            else
            {
                if (currentTriangleInRangeVertices.Count == 2)
                {
                    if (currentTriangleOutRangeVertices[0] == trianglesToComplete[i + 1])
                    {
                        triangles.Add(verticeIReferences[currentTriangleInRangeVertices[0]]);
                        vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[1]], meshToPrint.vertices[currentTriangleOutRangeVertices[0]]));
                        triangles.Add(vertices.Count - 1);
                        triangles.Add(verticeIReferences[currentTriangleInRangeVertices[1]]);
                        vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[0]], meshToPrint.vertices[currentTriangleOutRangeVertices[0]]));
                        triangles.Add(verticeIReferences[currentTriangleInRangeVertices[0]]);
                        triangles.Add(vertices.Count - 1);
                        triangles.Add(vertices.Count - 2);
                    }
                    else
                    {
                        triangles.Add(verticeIReferences[currentTriangleInRangeVertices[0]]);
                        triangles.Add(verticeIReferences[currentTriangleInRangeVertices[1]]);
                        vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[1]], meshToPrint.vertices[currentTriangleOutRangeVertices[0]]));
                        triangles.Add(vertices.Count - 1);
                        vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[0]], meshToPrint.vertices[currentTriangleOutRangeVertices[0]]));
                        triangles.Add(verticeIReferences[currentTriangleInRangeVertices[0]]);
                        triangles.Add(vertices.Count - 2);
                        triangles.Add(vertices.Count - 1);
                    }
                }
                else
                {
                    if (currentTriangleInRangeVertices.Count == 1)
                    {
                        vertices.Add(meshToPrint.vertices[trianglesToComplete[i + 1]]);
                        vertices.Add(meshToPrint.vertices[trianglesToComplete[i + 2]]);

                        if (currentTriangleInRangeVertices[0] == trianglesToComplete[i + 1])
                        {
                            vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[0]], meshToPrint.vertices[currentTriangleOutRangeVertices[0]]));
                            triangles.Add(vertices.Count - 1);
                            triangles.Add(verticeIReferences[currentTriangleInRangeVertices[0]]);
                            vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[0]], meshToPrint.vertices[currentTriangleOutRangeVertices[1]]));
                            triangles.Add(vertices.Count - 1);
                        }
                        else
                        {
                            triangles.Add(verticeIReferences[currentTriangleInRangeVertices[0]]);
                            vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[0]], meshToPrint.vertices[currentTriangleOutRangeVertices[0]]));
                            triangles.Add(vertices.Count - 1);
                            vertices.Add(CalculateVertice(y, meshToPrint.vertices[currentTriangleInRangeVertices[0]], meshToPrint.vertices[currentTriangleOutRangeVertices[1]]));
                            triangles.Add(vertices.Count - 1);
                        }
                    }
                }
                i += 3;
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        printedObject.GetComponent<MeshFilter>().mesh = mesh;
    }

    private Vector3 CalculateVertice(float y, Vector3 vertice1, Vector3 vertice2)
    {
        float y1, y2, x, x1, x2, z, z1, z2, lambda;

        y1 = vertice1.y;
        y2 = vertice2.y;
        x1 = vertice1.x;
        x2 = vertice2.x;
        z1 = vertice1.z;
        z2 = vertice2.z;

        lambda = (y - y1) / (y2 - y1);
        x = x1 + lambda * (x2 - x1);
        z = z1 + lambda * (z2 - z1);

        return new Vector3(x, y, z);
    }

    [ContextMenu("Print")]
    public void StartPrinting()
    {
        amountToPrint = 0;
        finishedPrinting = false;
        ResetMesh();
    }

    private void ResetMesh()
    {
        verticeIReferences = new Dictionary<int, int>();
        leftVerticeIReferences = new List<int>();
        usedVertices = new List<Vector3>();
        verticesLeftToUse = new List<Vector3>();

        trianglesToComplete = new List<int>();
        completedTriangles = new List<int>();

        amountToPrint = 0;
        meshToPrint = objectToPrint.mesh;

        meshToPrintMax = meshToPrint.vertices[0].y;
        meshToPrintMin = meshToPrintMax;

        for (int i = 1; i < meshToPrint.vertices.Length; i++)
        {
            if (meshToPrint.vertices[i].y < meshToPrintMin)
            {
                meshToPrintMin = meshToPrint.vertices[i].y;
            }

            if (meshToPrint.vertices[i].y > meshToPrintMax)
            {
                meshToPrintMax = meshToPrint.vertices[i].y;
            }
        }

        for (int i = 0; i < meshToPrint.vertices.Length; i++)
        {
            leftVerticeIReferences.Add(i);
        }

        meshToPrintHeigth = meshToPrintMax - meshToPrintMin;

        verticesLeftToUse = meshToPrint.vertices.ToList();
        trianglesToComplete = meshToPrint.triangles.ToList();
    }
}