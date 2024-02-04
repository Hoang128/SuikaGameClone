using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection;
using Assembly_CSharp_Editor.Assets.Sources.Scripts.Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameplayHandler : MonoBehaviour
{
    private ICircleManager circleManager;
    private int currMaxCircleSize;

    [SerializeField] private int initCircleNumber;
    [SerializeField] private List<InitCircleSizeSpaceParams> InitCircleSizeSpaceParamsList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    public void StartNewGame()
    {
        circleManager = Kernel.Instance.GetModule<ICircleManager>();
        currMaxCircleSize = 0;

        for (int i = 0; i < initCircleNumber; i++)
        {
            int size = Random.Range(InitCircleSizeSpaceParamsList[currMaxCircleSize].min, InitCircleSizeSpaceParamsList[currMaxCircleSize].max);
            circleManager.CreateCircle(size);
        }
        UpdateMaxCircleSize();
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
