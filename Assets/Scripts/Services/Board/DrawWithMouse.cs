using UnityEngine;

namespace AulaAtecaInteractive.Assets.Scripts.BoardService
{
    public class DrawWithMouse : MonoBehaviour
    {
        public bool canDraw = false;
        private LineRenderer line;
        private Vector3 previousPosition;

        [SerializeField] private float minimumDistance = 0.1f;

        private void Start()
        {
            line = GetComponent<LineRenderer>();
            previousPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && canDraw)
            {
                Vector3 currentPosirion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPosirion.z = 0;

                if (Vector3.Distance(previousPosition, currentPosirion) > minimumDistance)
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosirion);
                    previousPosition = currentPosirion;
                }
            }
        }
    }
}


