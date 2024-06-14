using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AulaAtecaInteractive.Assets.Scripts.BoardService
{
    public class PaintService : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Material material;
        public Color color = Color.black;
        public RectTransform canvasRectTransform;


        private void Update()
        {
            // Si el usuario hace clic izquierdo (o toca la pantalla)
            if (Input.GetMouseButtonDown(0))
            {
                // Lanza un rayo desde la c�mara del jugador
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Comprueba si el rayo golpea el Canvas
                if (Physics.Raycast(ray, out hit))
                {
                    // Si golpea el Canvas, comienza a pintar
                    if (hit.collider.gameObject == canvasRectTransform.gameObject)
                    {
                        StartPainting();
                    }
                }
            }
            // Si el usuario mantiene presionado el bot�n izquierdo del rat�n (o toca la pantalla)
            else if (Input.GetMouseButton(0))
            {
                // Dibuja la l�nea sobre el Canvas
                DrawLine();
            }
            // Si el usuario suelta el bot�n izquierdo del rat�n (o levanta el dedo de la pantalla)
            else if (Input.GetMouseButtonUp(0))
            {
                // Deja de pintar
                StopPainting();
            }
        }

        void StartPainting()
        {
            lineRenderer.positionCount = 0; // Restablecer el contador de posiciones
            lineRenderer.material = material;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.useWorldSpace = false;
        }

        void DrawLine()
        {
            // Lanza un rayo desde la c�mara del jugador
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Comprueba si el rayo golpea el Canvas
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                // Si golpea el Canvas, dibuja la l�nea sobre el Canvas
                if (hit.collider.gameObject == canvasRectTransform.gameObject)
                {
                    // Obt�n la posici�n local del punto de impacto
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, hit.point, Camera.main, out Vector2 localMousePosition);

                    // A�ade la posici�n al LineRenderer en coordenadas locales del Canvas
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, localMousePosition);
                }
            }
        }

        void StopPainting()
        {
        }
    }
}
