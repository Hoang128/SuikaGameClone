using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public interface ICircleManager : IModule
    {
        public void CreateCircle();
        public void CreateCircle(int size);
        public void ReturnCircle(Circle circle);
        public void MergeCircles(Circle circle1, Circle circle2);
        public int GetmaxCircleSize();
    }
}