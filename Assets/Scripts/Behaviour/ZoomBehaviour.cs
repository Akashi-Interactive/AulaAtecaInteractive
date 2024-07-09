using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomBehaviour : MonoBehaviour
{
    public float initialSize = 1.0f;
    public float zoomSize = 1.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.orthographicSize = zoomSize;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Camera.main.orthographicSize = initialSize;
        }
    }
}
