using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AulaAtecaInteractive
{
    public class PowerPointManager : MonoBehaviour, InteractableObj
    {
        public List<Texture> slides; // Lista de texturas de las diapositivas
        private int currentSlideIndex = 0;
        public GameObject canvas; // El canvas que muestra las diapositivas
        public RawImage slideImage; // El componente RawImage que mostrará la diapositiva actual
        private Camera mainCamera; // Referencia a la cámara principal
        public float offsetDistance; // Distancia hacia adelante del jugador
        public float tiltAngle; // Ángulo de inclinación hacia el techo
        public float heightOffset; // Desplazamiento en altura

        void Start()
        {
            mainCamera = Camera.main; // Obtener la cámara principal
            canvas.SetActive(false); // Asegurarse de que el canvas esté desactivado al inicio
        }

        public void Interact()
        {
            // Si el canvas no está activo, mostrarlo y mostrar la primera diapositiva
            if (!canvas.activeSelf)
            {
                canvas.SetActive(true);
                OrientCanvasTowardsPlayer();
                currentSlideIndex = 0;
                ShowSlide();
            }
            else
            {
                // Si el canvas está activo, avanzar a la siguiente diapositiva
                currentSlideIndex++;
                if (currentSlideIndex < slides.Count)
                {
                    ShowSlide();
                }
                else
                {
                    // Si ya se mostraron todas las diapositivas, cerrar el canvas
                    canvas.SetActive(false);
                }
            }
        }

        private void ShowSlide()
        {
            if (currentSlideIndex >= 0 && currentSlideIndex < slides.Count)
            {
                slideImage.texture = slides[currentSlideIndex];
            }
        }

        private void OrientCanvasTowardsPlayer()
        {
            // Mover el canvas un poco al frente del jugador y ajustar la altura
            Vector3 directionToPlayer = mainCamera.transform.position - canvas.transform.position;
            directionToPlayer.y = 0; // Mantener la rotación en el eje Y solamente
           
            // Rotar el canvas hacia el jugador
            canvas.transform.rotation = Quaternion.LookRotation(-directionToPlayer);

            // Aplicar inclinación hacia el techo
            canvas.transform.Rotate(Vector3.right, tiltAngle);
        }
    }
}
