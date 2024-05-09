using System.Collections.Generic;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    private IFruitManager fruitManager;
    private int currMaxFruitSize;

    [Header("Gameplay Settings")]
    [SerializeField] private int initFruitNumber;
    [SerializeField] private List<InitFruitSizeSpaceParams> InitFruitSizeSpaceParamsList;

    [Header("Gameplay Sub-Components")]
    [SerializeField] private FruitCreator fruitCreator;

    // Start is called before the first frame update
    void Start()
    {
        fruitManager = Kernel.Instance.GetModule<IFruitManager>();
        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    public void StartNewGame()
    {
        fruitManager.ClearAllFruits();
        fruitCreator.StartNewGame();
    }

    public void UpdateMaxCircleSize()
    {
        currMaxFruitSize = fruitManager.GetmaxFruitSize();
    }

    [System.Serializable]
    public class InitFruitSizeSpaceParams
    {
        public int min;
        public int max;
    }
}
