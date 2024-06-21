using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SVImageController : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image cursor;

    private RawImage svImage;

    [SerializeField]
    private ColourPickerController colourPickerController;

    private RectTransform rectTransform, cursorTransform;

    private void Awake()
    {
        svImage = GetComponent<RawImage>();
        rectTransform = GetComponent<RectTransform>();
        cursorTransform = cursor.GetComponent<RectTransform>();
        //cursorTransform.position = new Vector2(-(), -())
    }

    private void UpdateColour(PointerEventData eventData)
    {
        Vector3 position = rectTransform.InverseTransformPoint(eventData.position);

        float deltaX = rectTransform.sizeDelta.x * 0.5f;
        float deltaY = rectTransform.sizeDelta.y * 0.5f;

        position.x = Math.Max(-deltaX, Math.Min(position.x, deltaX));
        position.y = Math.Max(-deltaY, Math.Min(position.y, deltaY));

        float x = position.x + deltaX;
        float y = position.y + deltaY;

        float xNormalized = x / rectTransform.sizeDelta.x;
        float yNormalized = y / rectTransform.sizeDelta.y;

        cursorTransform.localPosition = position;
        cursor.color = Color.HSVToRGB(0, 0, 1 - yNormalized);

        colourPickerController.SetSV(xNormalized, yNormalized);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }
}
