using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChanger : MonoBehaviour
{
    [SerializeField] GameObject option;
    [SerializeField] GameObject menu;

    public void ChangeOption()
    {
        if (option.transform.localScale == Vector3.one)
        {
            option.transform.localScale = new Vector3(0.0000001f, 0.0000001f, 0.0000001f);
            menu.transform.localScale = Vector3.one;
        }
        else
        {
            option.SetActive(true);
            option.transform.localScale = Vector3.one;
            menu.transform.localScale = new Vector3(0.0000001f, 0.0000001f, 0.0000001f);
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Sale del juego
    public void ExitGame()
    {
        // Si estamos en el editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si estamos en una build
        Application.Quit();
#endif
    }
}