using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public void CreateCanvasObject(GameObject canvasObjectPrefab)
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();

            Vector3 centerOfCanvas = canvasRect.position + new Vector3(canvasRect.rect.center.x, canvasRect.rect.center.y, 0f);

            Instantiate(canvasObjectPrefab, centerOfCanvas, Quaternion.identity, canvas.transform);
        }
        else
        {
            Debug.LogError("No se pudo encontrar el objeto Canvas en la escena.");
        }
    }
}
