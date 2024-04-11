using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateObjectAndDisableClickables : MonoBehaviour
{
    public GameObject menu;
    public GameObject clickObject;
    private InputAction escAction;

    void Start()
    {
        // Asigna la acción correspondiente al botón "Esc"
        escAction = new InputAction(binding: "<Keyboard>/escape");
        escAction.started += _ => OnEscapePressed();
        escAction.Enable();
    }

    private void OnEscapePressed()
    {
        if (menu != null)
        {
            menu.SetActive(true);
        }
        DisableClickableObjects();
        Debug.Log("Esc pressed");
    }

    void DisableClickableObjects()
    {
        GameObject[] clickableObjects = GameObject.FindGameObjectsWithTag("Clickable");

        foreach (GameObject obj in clickableObjects)
        {
            ClickableObject clickableScript = obj.GetComponent<ClickableObject>();
            if (clickableScript != null)
            {
                clickableScript.enabled = false;
            }
        }
    }

    void OnDestroy()
    {
        // Asegúrate de deshabilitar la acción cuando el script sea destruido
        escAction.Disable();
    }
}
