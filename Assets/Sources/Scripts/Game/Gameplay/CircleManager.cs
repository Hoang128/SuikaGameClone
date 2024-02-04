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
        public ICircle CreateCircle()
        {
            return objectPool.GetObject<Circle>();
        }

        public ICircle CreateCircle(int size)
        {
            Circle circle = objectPool.GetObject<Circle>();
            circle.Init(size);
            return circle;
        }

        [Button]
        public void ReturnCircle(ICircle circle)
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

        public void MergeCircles(ICircle circle1, ICircle circle2)
        {
            ReturnCircle(circle1);
            ReturnCircle(circle2);
            ICircle newCircle = CreateCircle(circle1.Size + 1);
            newCircle.GetComponent<Transform>().position = (circle1.GetComponent<Transform>().position + circle2.GetComponent<Transform>().position) / 2f;
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