using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class CircleCreator : MonoBehaviour
    {
        private ICircle currCircle;
        private ICircle nextCircle;
        private Vector2 lastMousePosition;

        public ICircle CreateCircle(int size)
        {
            ICircle circle = Kernel.Instance.GetModule<ICircleManager>().CreateCircle(size);
            return circle;
        }

        public void SetNextCircle(ICircle circle)
        {
            nextCircle = circle;
            nextCircle.SetGravity(false);
            nextCircle.GetComponent<Collider2D>().enabled = false;
            nextCircle.GetComponent<Transform>().position = new Vector3(1.5f, 4.5f, 0f);
        }

        public void SetCurrCircle(ICircle circle)
        {
            currCircle = circle;
            currCircle.SetGravity(false);
            currCircle.GetComponent<Collider2D>().enabled = false;
            currCircle.GetComponent<Transform>().position = transform.position;
        }

        public void StartNewGame()
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            lastMousePosition = transform.position;

            SetCurrCircle(CreateCircle(1));
            SetNextCircle(CreateCircle(1));
        }

        public void Update()
        {
            if (currCircle == null || nextCircle == null)
                return;

            if (Input.GetMouseButtonUp(0))
            {
                currCircle.SetGravity(true);
                currCircle.GetComponent<Collider2D>().enabled = true;
                SetCurrCircle(nextCircle);
                SetNextCircle(CreateCircle(Random.Range(1, 7)));
                Debug.Log("Next circle size: " + nextCircle.Size);
                Debug.Log("Current circle size: " + currCircle.Size);
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(0))
            {
                if (Mathf.Abs(mousePos.x - lastMousePosition.x) > 0f)
                {
                    transform.position = new Vector3(Mathf.Clamp(mousePos.x, -2f, 2f), transform.position.y, transform.position.z);
                    currCircle.GetComponent<Transform>().position = transform.position;
                }
            }
            
            lastMousePosition = mousePos;
        }
    }
}