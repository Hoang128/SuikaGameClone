namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool
{
    public interface IPoolable
    {
        public IObjectPool Pool { get; set; }
        public void OnCreate();
        public void OnGet();
        public void OnReturn();
        public T GetComponent<T>();
    }
}