using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class FruitCreator : MonoBehaviour
    {
        private IFruit currFruit;
        private IFruit nextFruit;
        private Vector2 lastMousePosition;

        public IFruit CreateFruit(int size)
        {
            IFruit fruit = Kernel.Instance.GetModule<IFruitManager>().CreateFruit(size);
            return fruit;
        }

        public void SetNextFruit(IFruit circle)
        {
            nextFruit = circle;
            nextFruit.SetGravity(false);
            nextFruit.GetComponent<Collider2D>().enabled = false;
            nextFruit.GetComponent<Transform>().position = new Vector3(1.5f, 4.5f, 0f);
        }

        public void SetCurrFruit(IFruit circle)
        {
            currFruit = circle;
            currFruit.SetGravity(false);
            currFruit.GetComponent<Collider2D>().enabled = false;
            currFruit.GetComponent<Transform>().position = transform.position;
        }

        public void StartNewGame()
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            lastMousePosition = transform.position;

            SetCurrFruit(CreateFruit(1));
            SetNextFruit(CreateFruit(1));
        }

        public void Update()
        {
            if (currFruit == null || nextFruit == null)
                return;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
                currFruit.GetComponent<Transform>().position = transform.position;
                currFruit.GetComponent<Collider2D>().enabled = true;
                currFruit.SetGravity(true);
                SetCurrFruit(nextFruit);
                SetNextFruit(CreateFruit(Random.Range(1, 7)));
                Debug.Log("Next circle size: " + nextFruit.Size);
                Debug.Log("Current circle size: " + currFruit.Size);
            }

            if (Input.GetMouseButton(0))
            {
                if (Mathf.Abs(mousePos.x - lastMousePosition.x) > 0f)
                {
                    transform.position = new Vector3(Mathf.Clamp(mousePos.x, -2f, 2f), transform.position.y, transform.position.z);
                    currFruit.GetComponent<Transform>().position = transform.position;
                }
            }
            
            lastMousePosition = mousePos;
        }
    }
}