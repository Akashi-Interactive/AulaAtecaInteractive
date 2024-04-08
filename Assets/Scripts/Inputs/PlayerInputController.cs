using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController Instance { get; private set; }
    public static event Action OnInteractEvent;


    private Vector3 movementDirection;
    private Vector2 lookDirection;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Ya hay una instancia de PlayerInputController en la escena.");
            Destroy(gameObject);
        }
    }


    public void OnMove(InputValue moveValue)
    {
      //  Debug.Log(moveValue.Get<Vector2>());
        Vector2 inputVector = moveValue.Get<Vector2>();
        movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);
    }

    public void OnLook(InputValue lookValue)
    {
       // Debug.Log(lookValue.Get<Vector2>());
        lookDirection = lookValue.Get<Vector2>();
    }

    public void OnInteract()
    {
        OnInteractEvent?.Invoke();
    }

    public Vector3 GetPlayerInputMovementDirection()
    {
        return movementDirection;
    }

    public Vector2 GetPlayerInputLookDirection()
    {
        return lookDirection;
    }
}


