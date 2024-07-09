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
        public RawImage slideImage; // El componente RawImage que mostrará la diapositiva actual
        private Camera mainCamera; // Referencia a la cámara principal
        public float offsetDistance; // Distancia hacia adelante del jugador
        public float tiltAngle; // Ángulo de inclinación hacia el techo
        public float heightOffset; // Desplazamiento en altura
        public float animationDuration = 0.5f; // Duración de la animación

        void Start()
        {
            mainCamera = Camera.main; // Obtener la cámara principal
            slideImage.gameObject.SetActive(false); // Asegurarse de que el RawImage esté desactivado al inicio
            slideImage.transform.localScale = Vector3.zero; // Escala inicial en cero para la animación
        }

        public void Interact()
        {
            // Si el RawImage no está activo, mostrarlo y mostrar la primera diapositiva
            if (!slideImage.gameObject.activeSelf)
            {
                slideImage.gameObject.SetActive(true);
                currentSlideIndex = 0;
                ShowSlide();
                StartCoroutine(ScaleImage(Vector3.one, animationDuration));
            }
            else
            {
                // Si el RawImage está activo, avanzar a la siguiente diapositiva
                currentSlideIndex++;
                if (currentSlideIndex < slides.Count)
                {
                    ShowSlide();
                }
                else
                {
                    // Si ya se mostraron todas las diapositivas, iniciar animación de cierre
                    StartCoroutine(ScaleImage(Vector3.zero, animationDuration, () => slideImage.gameObject.SetActive(false)));
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

        private IEnumerator ScaleImage(Vector3 targetScale, float duration, System.Action onComplete = null)
        {
            Vector3 initialScale = slideImage.transform.localScale;
            float timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                slideImage.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            slideImage.transform.localScale = targetScale;
            onComplete?.Invoke();
        }
    }
}
