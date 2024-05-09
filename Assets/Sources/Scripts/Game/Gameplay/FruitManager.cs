using System.Collections.Generic;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public class FruitManager : MonoBehaviour, IFruitManager
    {
        private IObjectPool objectPool;

        private void Awake()
        {
            objectPool = GetComponent<IObjectPool>();
        }

        [Button]
        public IFruit CreateFruit()
        {
            return objectPool.GetObject<Fruit>();
        }

        public IFruit CreateFruit(int size)
        {
            Fruit fruit = objectPool.GetObject<Fruit>();
            fruit.Init(size);
            return fruit;
        }

        [Button]
        public void ReturnFruit(IFruit circle)
        {
            objectPool.ReturnObject(circle);
        }

        public void InitModule()
        {
            
        }

        [Button]
        public void ClearAllFruits()
        {
            objectPool.ResetPool();
        }

        public void MergeFruits(IFruit fruit1, IFruit fruit2)
        {
            ReturnFruit(fruit1);
            ReturnFruit(fruit2);
            IFruit mergedFruit = CreateFruit(fruit1.Size + 1);
            mergedFruit.GetComponent<Transform>().position = (fruit1.GetComponent<Transform>().position + fruit2.GetComponent<Transform>().position) / 2f;
        }

        public int GetmaxFruitSize()
        {
            List<Fruit> fruits = objectPool.GetAllUsedObjects<Fruit>();
            int max = 0;
            foreach(Fruit fruit in fruits)
            {
                if (fruit.Size > max)
                {
                    max = fruit.Size;
                }
            }
            return max;
        }
    }
}