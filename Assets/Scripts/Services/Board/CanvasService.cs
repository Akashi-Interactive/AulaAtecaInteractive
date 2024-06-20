using AulaAtecaInteractive.Assets.Scripts.BoardService;
using UnityEngine;

public class CanvasService : MonoBehaviour
{
    public Canvas canvas;
    private RectTransform canvasRectTransform;
    private Vector3 originalPosition;
    private Vector2 originalSizeDelta;
    private RenderMode originalRenderMode;
    public DrawWithMouse drawWithMouse;

    private void Start()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        originalPosition = canvasRectTransform.position;
        originalSizeDelta = canvasRectTransform.sizeDelta;
        originalRenderMode = canvas.renderMode;
    }

    public void SetCanvasToScreen()
    {
        canvasRectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        canvasRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        drawWithMouse.canDraw = true;
    }

    public void SetCanvasToOriginal()
    {
        canvasRectTransform.position = originalPosition;
        canvasRectTransform.sizeDelta = originalSizeDelta;
        canvas.renderMode = originalRenderMode;
        drawWithMouse.canDraw = false;
    }
}
