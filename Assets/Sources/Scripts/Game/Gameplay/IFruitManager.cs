using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public interface IFruitManager : IModule
    {
        public IFruit CreateFruit();
        public IFruit CreateFruit(int size);
        public void ReturnFruit(IFruit circle);
        public void MergeFruits(IFruit circle1, IFruit circle2);
        public int GetmaxFruitSize();
        public void ClearAllFruits();
    }
}