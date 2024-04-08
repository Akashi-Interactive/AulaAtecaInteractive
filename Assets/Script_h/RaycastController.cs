using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    // LayerMask para especificar qué capas deben ser consideradas en el raycast
    public LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit);
                // Aquí puedes agregar lo que quieras hacer cuando el raycast golpea un objeto
                // Por ejemplo, puedes llamar a una función en el objeto golpeado
                hit.collider.gameObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
