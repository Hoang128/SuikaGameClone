using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class Circle : MonoBehaviour, IPoolable
    {
        private SpriteRenderer spriteRenderer;
        private CircleCollider2D circleCollider;
        private Rigidbody2D rb2D;

        public IObjectPool Pool { get; set; }

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
    }
}