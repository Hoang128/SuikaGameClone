using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Kernel.Instance.SetModule<ICircleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
