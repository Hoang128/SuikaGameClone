using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection
{
    public class Kernel : MonoBehaviour, IKernel
    {
        public static Kernel Instance;
        private readonly Dictionary<Type, IModule> _bindings = new Dictionary<Type, IModule>();

        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void SetModule<TModule>() where TModule : IModule
        {
            Type moduleType = typeof(TModule);
            for (var i = 0; i < transform.childCount; i++)
            {
                if (moduleType.IsAssignableFrom(transform.GetChild(i).GetComponent<TModule>().GetType()))
                {
                    IModule module = transform.GetChild(i).GetComponent<TModule>();
                    module.InitModule();
                    _bindings.Add(moduleType, module);
                    break;
                }
            }
        }

        public TModule GetModule<TModule>() where TModule : IModule
        {
            return (TModule) _bindings[typeof(TModule)];
        }
    }
}