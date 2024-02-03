using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class CircleManager : MonoBehaviour, ICircleManager
    {
        private IObjectPool objectPool;

        private void Awake()
        {
            objectPool = GetComponent<IObjectPool>();
        }

        [Button]
        public void CreateCircle()
        {
            objectPool.GetObject<Circle>();
        }

        [Button]
        public void ReturnCircle(Circle circle)
        {
            objectPool.ReturnObject(circle);
        }

        public void InitModule()
        {
            
        }

        [Button]
        public void ClearAllCircles()
        {
            objectPool.ResetPool();
        }
    }
}