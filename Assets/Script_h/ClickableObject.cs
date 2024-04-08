using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    private ObjectController controller;

    private void Start()
    {
        controller = FindObjectOfType<ObjectController>();
        if (controller == null)
        {
            Debug.LogError("No se pudo encontrar el ObjectController en la escena.");
        }
    }

    public void OnClick()
    {
        if (controller != null && prefabToInstantiate != null)
        {
            controller.CreateCanvasObject(prefabToInstantiate);
        }
    }
}
