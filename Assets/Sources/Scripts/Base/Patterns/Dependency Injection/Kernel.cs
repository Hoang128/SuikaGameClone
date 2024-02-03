using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp_Editor.Assets.Sources.Scripts.Base.Patterns.Dependency_Injection
{
    public class Kernel : MonoBehaviour, IKernel
    {
        private static Kernel _instance;
        private readonly Dictionary<Type, IModule> _bindings = new Dictionary<Type, IModule>();

        public void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void SetModule<TModule>() where TModule : IModule
        {
            Type moduleType = typeof(TModule);
            for (var i = 0; i < transform.childCount; i++)
            {
                if (moduleType.IsAssignableFrom(transform.GetChild(i).GetType()))
                {
                    IModule module = transform.GetChild(i) as IModule;
                    ((TModule)module).InitModule();
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