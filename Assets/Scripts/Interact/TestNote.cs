using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AulaAtecaInteractive
{
    public class TestNote : MonoBehaviour, InteractableObj
    {
        public string message = "Este es el mensaje de la nota.";

    public void Interact()
    {
        // Aquí puedes mostrar el mensaje en un canvas
        Debug.Log(message);
    }
        
    }
}
