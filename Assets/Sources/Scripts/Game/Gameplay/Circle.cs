using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class Circle : MonoBehaviour, ICircle
    {
        [SerializeField] float scaleRatio = 0.1f;
        private SpriteRenderer spriteRenderer;
        private CircleCollider2D circleCollider;
        private Rigidbody2D rb2D;

        public IObjectPool Pool { get; set; }
        public int Size { get; set; }

        public void OnCreate()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            circleCollider = GetComponent<CircleCollider2D>();
            rb2D = GetComponent<Rigidbody2D>();
        }
        
        public void OnGet()
        {
            //throw new System.NotImplementedException();
        }

        public void OnReturn()
        {
            //throw new System.NotImplementedException();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("Circle"))
            {
                return;
            }
            if (rb2D.gravityScale == 0f || collision.transform.GetComponent<Rigidbody2D>().gravityScale == 0f)
            {
                return;
            }
            if (collision.transform.GetComponent<ICircle>().Size == Size)
            {
                Kernel.Instance.GetModule<ICircleManager>().MergeCircles(this, collision.transform.GetComponent<ICircle>());
            }
        }

        public void Init(int size)
        {
            Size = size;
            float sizeScale = size * scaleRatio;
            transform.localScale = new Vector3(sizeScale, sizeScale, 1);
            switch (size)
            {
                case 1:
                    spriteRenderer.color = Color.red;
                    break;
                case 2:
                    spriteRenderer.color = Color.green;
                    break;
                case 3:
                    spriteRenderer.color = Color.blue;
                    break;
                case 4:
                    spriteRenderer.color = Color.yellow;
                    break;
                case 5:
                    spriteRenderer.color = Color.magenta;
                    break;
                case 6:
                    spriteRenderer.color = Color.cyan;
                    break;
                case 7:
                    spriteRenderer.color = Color.white;
                    break;
                case 8:
                    spriteRenderer.color = Color.black;
                    break;
                case 9:
                    spriteRenderer.color = Color.grey;
                    break;
                case 10:
                    spriteRenderer.color = Color.grey;
                    break;
            }
        }

        public void SetGravity(bool isCanDrop)
        {
            rb2D.gravityScale = isCanDrop ? 1 : 0;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}