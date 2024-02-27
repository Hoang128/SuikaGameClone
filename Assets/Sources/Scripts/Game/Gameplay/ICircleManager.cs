using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public interface ICircleManager : IModule
    {
        public ICircle CreateCircle();
        public ICircle CreateCircle(int size);
        public void ReturnCircle(ICircle circle);
        public void MergeCircles(ICircle circle1, ICircle circle2);
        public int GetmaxCircleSize();
        public void ClearAllCircles();
    }
}