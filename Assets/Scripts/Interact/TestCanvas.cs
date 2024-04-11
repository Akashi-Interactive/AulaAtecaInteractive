using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AulaAtecaInteractive
{
    
    public class TestCanvas : MonoBehaviour, InteractableObj
    {
        [SerializeField] private GameObject objCanvas;

       public void Interact(){
            objCanvas.SetActive(true);
       }
       
    }
}
