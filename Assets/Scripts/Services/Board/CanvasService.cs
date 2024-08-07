using AulaAtecaInteractive.Assets.Scripts.BoardService;
using UnityEngine;

public class CanvasService : MonoBehaviour
{
    public Canvas canvas;
    private RectTransform canvasRectTransform;
    private Vector3 originalPosition;
    private Vector2 originalSizeDelta;
    private RenderMode originalRenderMode;
    public GameObject boardCanvas;
    public DrawWithMouse drawWithMouse;
    public PlayerController playerController;

    private void Start()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        originalPosition = canvasRectTransform.position;
        originalSizeDelta = canvasRectTransform.sizeDelta;
        originalRenderMode = canvas.renderMode;
    }

    public void SetCanvasToScreen()
    {/*
        canvasRectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        canvasRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;*/
        boardCanvas.SetActive(true);
        drawWithMouse.canDraw = true;
        CursorController.EnableCursor();
        playerController.SetCanMove(false);
    }

    public void SetCanvasToOriginal()
    {/*
        canvasRectTransform.position = originalPosition;
        canvasRectTransform.sizeDelta = originalSizeDelta;
        canvas.renderMode = originalRenderMode;*/
        boardCanvas.SetActive(false);
        drawWithMouse.canDraw = false;
        CursorController.DisableCursor();
        AudioManager.Instance.UnPauseAudio();
        playerController.SetCanMove(true);
    }
}
