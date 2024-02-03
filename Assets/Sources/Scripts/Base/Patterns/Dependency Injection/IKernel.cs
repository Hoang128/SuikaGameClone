namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection
{
    public interface IKernel
    {
        void SetModule<TModule>() where TModule : IModule;
        TModule GetModule<TModule>() where TModule : IModule;
    }
}