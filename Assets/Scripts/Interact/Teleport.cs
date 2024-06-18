using UnityEngine;

public class Teleport : MonoBehaviour, InteractableObj
{
    public GameObject targetObject; // El objeto destino al que se teletransportará el jugador

    public void Interact()
    {
        TeleportToTarget();
    }

    private void TeleportToTarget()
    {
        if (targetObject != null)
        {
            Transform playerTransform = GetComponent<Transform>();
            playerTransform.position = targetObject.transform.position;
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }
}

