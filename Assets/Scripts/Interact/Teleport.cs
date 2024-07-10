using UnityEngine;

namespace AulaAtecaInteractive
{
    public class Teleport : MonoBehaviour, InteractableObj
    {
        public GameObject targetObject; // El objeto destino al que se teletransportará el jugador
        public string playerObjectName = "Player"; // Nombre del objeto del jugador

        private Transform playerTransform;
        private CharacterController playerController;

        private void Start()
        {
            // Buscar el objeto del jugador por su nombre y obtener su transform
            GameObject playerObject = GameObject.Find(playerObjectName);
            if (playerObject != null)
            {
                playerTransform = playerObject.transform;
                playerController = playerObject.GetComponent<CharacterController>();
                if (playerController == null)
                {
                    Debug.LogError("CharacterController component not found on the player object.");
                }
                else
                {
                    Debug.Log("Player object and CharacterController found and assigned.");
                }
            }
            else
            {
                Debug.LogError($"Player object with name '{playerObjectName}' not found.");
            }

            if (targetObject != null)
            {
                Debug.Log("Target object assigned.");
            }
            else
            {
                Debug.LogError("Target object is not assigned.");
            }
        }

        public void Interact()
        {
            Debug.Log("Interact method called.");
            TeleportToTarget();
        }

        private void OnTriggerEnter(Collider other)
        {
            TeleportToTarget();
        }

        private void TeleportToTarget()
        {
            if (targetObject != null && playerTransform != null && playerController != null)
            {
                Debug.Log("Teleporting player...");

                // Temporarily disable the CharacterController to teleport the player
                playerController.enabled = false;

                // Teleport the player and match the target object's rotation
                playerTransform.position = targetObject.transform.position;
                playerTransform.rotation = targetObject.transform.rotation;

                playerController.enabled = true;

                Debug.Log("Player teleported to target position and rotation.");
            }
            else
            {
                if (targetObject == null)
                {
                    Debug.LogError("Target object is not assigned.");
                }
                if (playerTransform == null)
                {
                    Debug.LogError($"Player object with name '{playerObjectName}' not found.");
                }
                if (playerController == null)
                {
                    Debug.LogError("CharacterController component not found on the player object.");
                }
            }
        }
    }
}
