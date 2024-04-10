using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del jugador
    public float sensitivity = 2.0f; // Sensibilidad del ratón
    public float interactionDistance = 10f; // Distancia de interacción

    private CharacterController controller;
    private Camera playerCamera;
    private float rotationX = 0;
    private PlayerInputController playerInputController;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        playerInputController = PlayerInputController.Instance;

        // Bloquear y ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la dirección hacia la que la cámara está mirando
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0f; // Asegurarse de que el movimiento sea en el plano horizontal
        forward.Normalize();

        // Obtener la dirección del movimiento del jugador
        Vector3 moveDirection = playerInputController.GetPlayerInputMovementDirection();

        // Movimiento relativo a la dirección de la cámara
        if (moveDirection.magnitude != 0)
        {
            // Rotar la dirección del movimiento del jugador según la dirección de la cámara
            moveDirection = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0) * moveDirection;
            moveDirection.Normalize(); // Normalizar para mantener la misma velocidad en todas las direcciones
        }

        // Movimiento del jugador usando el controlador de entrada
        controller.Move(moveDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("intentando interacturar");
            // Obtener la dirección hacia la que la cámara está mirando
            Vector3 raycastDirection = playerCamera.transform.forward;

            // Lanzar un Raycast desde el centro de la cámara
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, raycastDirection, out hit, interactionDistance))
            {
                // Verificar si el objeto golpeado es interactuable
                InteractableObj interactable = hit.collider.GetComponent<InteractableObj>();
                if (interactable != null)
                {
                    // Si es interactuable, llamar al método Interact()
                    interactable.Interact();
                }
            }
        }
    }


    void LateUpdate()
    {
        Vector2 lookInput = playerInputController.GetPlayerInputLookDirection();
        rotationX -= lookInput.y * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * lookInput.x * sensitivity);
    }
}







