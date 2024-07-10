using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AulaAtecaInteractive
{
    public class ModelViewer : MonoBehaviour, InteractableObj
    {
        public GameObject modelPrefab; // Prefab del modelo 3D que se instanciará
        private GameObject instantiatedModel; // Instancia del modelo 3D
        private Camera mainCamera; // Referencia a la cámara principal
        public float animationDuration = 0.5f; // Duración de la animación
        public float rotationSpeed = 10f; // Velocidad de rotación del modelo
        public float heightOffset = 1f; // Desplazamiento en altura
        public Vector3 initialScale = Vector3.one; // Escala inicial del modelo
        public Vector3 rotationOffset = Vector3.zero; // Offset de rotación

        private bool isInteracting = false; // Para verificar si está interactuando

        void Start()
        {
            mainCamera = Camera.main; // Obtener la cámara principal
        }

        void Update()
        {
            if (isInteracting && instantiatedModel != null)
            {
                // Rotar el modelo lentamente
                instantiatedModel.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
               // instantiatedModel.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.World);
               // instantiatedModel.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.World);
            }
        }

        public void Interact()
        {
            if (instantiatedModel == null)
            {
                // Instanciar el modelo y configurar su escala inicial
                instantiatedModel = Instantiate(modelPrefab, GetModelPosition(), Quaternion.identity);
                instantiatedModel.transform.localScale = Vector3.zero;
                instantiatedModel.SetActive(true);
                OrientModelTowardsPlayer();
                StartCoroutine(ScaleModel(initialScale, animationDuration, () => isInteracting = true));
            }
            else
            {
                // Iniciar animación de cierre y destruir el modelo después
                StartCoroutine(ScaleModel(Vector3.zero, animationDuration, () =>
                {
                    Destroy(instantiatedModel);
                    isInteracting = false;
                }));
            }
        }

        private Vector3 GetModelPosition()
        {
            Vector3 position = transform.position;
            position.y += heightOffset;
            return position;
        }

        private void OrientModelTowardsPlayer()
        {
            if (instantiatedModel != null)
            {
                // Mover el modelo un poco al frente del jugador y ajustar la altura
                Vector3 directionToPlayer = mainCamera.transform.position - instantiatedModel.transform.position;
                directionToPlayer.y = 0; // Mantener la rotación en el eje Y solamente

                // Rotar el modelo hacia el jugador y aplicar el offset de rotación
                instantiatedModel.transform.rotation = Quaternion.LookRotation(-directionToPlayer) * Quaternion.Euler(rotationOffset);
            }
        }

        private IEnumerator ScaleModel(Vector3 targetScale, float duration, System.Action onComplete = null)
        {
            if (instantiatedModel != null)
            {
                Vector3 initialScale = instantiatedModel.transform.localScale;
                float timeElapsed = 0f;

                while (timeElapsed < duration)
                {
                    instantiatedModel.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }

                instantiatedModel.transform.localScale = targetScale;
                onComplete?.Invoke();
            }
        }
    }
}
