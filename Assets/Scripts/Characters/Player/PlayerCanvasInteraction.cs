using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AulaAtecaInteractive.Assets.Scripts.Characters
{
    public class PlayerCanvasInteraction : MonoBehaviour
    {
        public Camera playerCamera;
        public Canvas canvas;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject == canvas.gameObject)
                    {
                        Vector2 localPoint;
                        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, hit.point, playerCamera, out localPoint);

                        // Aqu� tienes la posici�n local del punto de impacto en el Canvas
                        Debug.Log("Posici�n local en el Canvas: " + localPoint);
                    }
                }
            }
        }
    }
}
