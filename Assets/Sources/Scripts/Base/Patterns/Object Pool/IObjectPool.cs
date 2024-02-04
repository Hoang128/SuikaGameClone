using System.Collections.Generic;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool
{
    public interface IObjectPool
    {
        public void CreatePool<T>(int size) where T : IPoolable;
        public T GetObject<T>() where T : IPoolable;
        public void ReturnObject<T>(T obj) where T : IPoolable;
        public void ResetPool();
        public List<T> GetAllUsedObjects<T>() where T : IPoolable;
    }
}