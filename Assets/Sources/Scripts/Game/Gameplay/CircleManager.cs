using System.Collections.Generic;
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

        public void CreateCircle(int size)
        {
            Circle circle = objectPool.GetObject<Circle>();
            circle.Init(size);
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

        public void MergeCircles(Circle circle1, Circle circle2)
        {
            ReturnCircle(circle1);
            ReturnCircle(circle2);
        }

        public int GetmaxCircleSize()
        {
            List<Circle> circles = objectPool.GetAllUsedObjects<Circle>();
            int max = 0;
            foreach(Circle circle in circles)
            {
                if (circle.Size > max)
                {
                    max = circle.Size;
                }
            }
            return max;
        }
    }
}