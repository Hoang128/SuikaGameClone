using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool
{
    public interface IObjectPool
    {
        public void CreatePool<T>(int size) where T : IPoolable;
        public T GetObject<T>() where T : IPoolable;
        public void ReturnObject<T>(T obj) where T : IPoolable;
        public void ResetPool();
    }
}