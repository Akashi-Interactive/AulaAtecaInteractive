using UnityEngine;

namespace AulaAtecaInteractive
{

    public class TestCanvas : MonoBehaviour, InteractableObj
    {
        [SerializeField] private FadeCanvasTransition objCanvas;

        private bool active = false;

       public void Interact(){
            active = !active;

            if(active)
                objCanvas.StartFadeIn();
            else
                objCanvas.StartFadeOut();
       }
    }
}
