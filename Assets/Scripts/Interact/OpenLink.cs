using UnityEngine;

public class OpenLink : MonoBehaviour, InteractableObj
{
    public string itchIoLink = "https://kindanice.itch.io/bases-loaded"; // Enlace a abrir en Itch.io

    public void Interact()
    {
        OpenInNewTab(itchIoLink);
    }

    private void OpenInNewTab(string url)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        OpenInNewTabWebGL(url);
        #else
        Application.OpenURL(url);
        #endif
    }

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void OpenInNewTabWebGL(string url);
}
