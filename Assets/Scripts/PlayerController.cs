using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del jugador
    public float sensitivity = 2.0f; // Sensibilidad del ratón

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
        Vector3 moveDirection = playerInputController.GetPlayerInputDirection();
        
        // Si no hay entrada de movimiento, establece moveDirection en Vector3.zero
        if (moveDirection.magnitude == 0)
        {
            moveDirection = Vector3.zero;
        }

        // Movimiento del jugador usando el controlador de entrada
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        Vector2 lookInput = playerInputController.GetPlayerLookDirection();
        rotationX -= lookInput.y * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * lookInput.x * sensitivity);
    }
}







