using System.Collections.Generic;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    private ICircleManager circleManager;
    private int currMaxCircleSize;

    [Header("Gameplay Settings")]
    [SerializeField] private int initCircleNumber;
    [SerializeField] private List<InitCircleSizeSpaceParams> InitCircleSizeSpaceParamsList;

    [Header("Gameplay Sub-Components")]
    [SerializeField] private CircleCreator circleCreator;

    // Start is called before the first frame update
    void Start()
    {
        circleManager = Kernel.Instance.GetModule<ICircleManager>();
        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    public void StartNewGame()
    {
        circleManager.ClearAllCircles();
        circleCreator.StartNewGame();
    }

    public void UpdateMaxCircleSize()
    {
        currMaxCircleSize = circleManager.GetmaxCircleSize();
    }

    [System.Serializable]
    public class InitCircleSizeSpaceParams
    {
        public int min;
        public int max;
    }
}
