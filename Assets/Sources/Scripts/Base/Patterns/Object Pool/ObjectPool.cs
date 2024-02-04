using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool
{
    public class ObjectPool : MonoBehaviour, IObjectPool
    {
        [SerializeField] private GameObject _poolObject;
        [SerializeField] private int _poolSize;
        [SerializeField] private Transform _poolParent;
        
        private List<IPoolable> _usedObjects = new List<IPoolable>();
        private Stack<IPoolable> _freeObjects = new Stack<IPoolable>();

        private void Awake()
        {
            _usedObjects = new List<IPoolable>(_poolSize);
            _freeObjects = new Stack<IPoolable>(_poolSize);

            CreatePool<IPoolable>(_poolSize);
        }

        public void CreatePool<T>(int size) where T : IPoolable
        {
            for (var i = 0; i < _poolSize; i++)
            {
                SpawnNew<IPoolable>();
            }
        }

        public T GetObject<T>() where T : IPoolable
        {
            if (_freeObjects.Count == 0)
            {
                SpawnNew<T>();
            }

            IPoolable poolable = _freeObjects.Pop();
            _usedObjects.Add(poolable);
            poolable.GetComponent<Transform>().gameObject.SetActive(true);
            poolable.OnGet();
            return (T)poolable;
        }

        public void ReturnObject<T>(T obj) where T : IPoolable
        {
            IPoolable poolable = obj;
            poolable.GetComponent<Transform>().gameObject.SetActive(false);
            poolable.OnReturn();
            _usedObjects.Remove(obj);
            _freeObjects.Push(poolable);
        }

        private T SpawnNew<T>()
        {
            GameObject newObject = Instantiate(_poolObject, _poolParent);
            newObject.SetActive(false);
            IPoolable poolable = newObject.GetComponent<IPoolable>();
            poolable.Pool = this;
            poolable.OnCreate();
            _freeObjects.Push(poolable);
            return newObject.GetComponent<T>();
        }

        public void ResetPool()
        {
            foreach (var usedObject in _usedObjects)
            {
                usedObject.GetComponent<Transform>().gameObject.SetActive(false);
                usedObject.OnReturn();
                _freeObjects.Push(usedObject);
            }
            _usedObjects.Clear();
        }

        public List<T> GetAllUsedObjects<T>() where T : IPoolable
        {
            return _usedObjects.Cast<T>().ToList();
        }
    }
}