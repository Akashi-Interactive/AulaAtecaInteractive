using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastController : MonoBehaviour
{
    public LayerMask layerMask;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit);
                hit.collider.gameObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
