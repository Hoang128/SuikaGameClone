using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class Circle : MonoBehaviour, ICircle
    {
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
            
        }

        public void Init(int size)
        {
            transform.localScale = new Vector3(size, size, 1);
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
    }
}