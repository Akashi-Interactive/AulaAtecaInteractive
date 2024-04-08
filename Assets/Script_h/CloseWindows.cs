using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindows : MonoBehaviour
{
    public GameObject gameObject;
    
    public void Close()
    {
        Destroy(gameObject);
    }
}
