using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace AulaAtecaInteractive.Assets.Scripts.Canvas
{
    /// <summary>
    /// <c>CanvasInteraction</c> allows interaction event with a canvas.
    /// </summary>
    public class CanvasInteraction : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private LayerMask uiLayerMask;

        private Camera mainCamera;

        private void Start()
        {
            Init();
        }

        #region Init Method
        /// <summary>
        /// Initialize event.
        /// </summary>
        private void Init()
        {
            PlayerInputController.OnInteractEvent += GetCanvasClickPosition;

            mainCamera = Camera.main;
        }
        #endregion

        #region Check Canvas Method
        /// <summary>
        /// Try to get canvas postion impact point.
        /// </summary>
        private void GetCanvasClickPosition()
        {
            var mousePosition = Mouse.current.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));

            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            List<RaycastResult> results = new List<RaycastResult>();
            pointerEventData.position = mousePosition;
            eventSystem.RaycastAll(pointerEventData, results);

            results.RemoveAll(result => !IsUiElement(result.gameObject));

            if (results.Count > 0)
            {
                // If UI is hit, handle UI interaction here
                Debug.Log("UI Element Hit!");
            }
            else
            {
                // If no UI is hit, handle canvas interaction here
                //Debug.Log("World Position: " + worldPosition);
            }
        }
        #endregion

        #region IsUiElement Method
        /// <summary>
        /// Determinates if the gameobject is in UI layer.
        /// </summary>
        /// <param name="gameObject">object to check.</param>
        /// <returns>True or false depending if in UI layer.</returns>
        private bool IsUiElement(GameObject gameObject)
        {
            while (gameObject != null)
            {
                if ((uiLayerMask & (1 << gameObject.layer)) != 0)
                {
                    return true;
                }
                gameObject = gameObject.transform.parent?.gameObject;
            }
            return false;
        }
        #endregion

        public void HandleInteraction(Vector3 hitPosition)
        {
            // Realizar l�gica en el Canvas basada en la posici�n del impacto
            Debug.Log("Impacto en la posici�n del Canvas: " + hitPosition);
        }
    }
}