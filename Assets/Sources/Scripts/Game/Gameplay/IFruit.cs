using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Object_Pool;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay
{
    public interface IFruit : IPoolable
    {
        public int Size { get; set; }
        public void Init(int size);
        public void SetGravity(bool isCanDrop);
    }
}