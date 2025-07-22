using System;
using NaughtyAttributes;
using UnityEngine;

namespace Cobra.DesignPattern
{
    public abstract class Singleton<T> : MonoBehaviour
        where T : class
    {
        [SerializeField] private bool dontDestroyOnLoad;
        protected static T instance = null;

        private void Awake()
        {
            if(dontDestroyOnLoad) DontDestroyOnLoad(this);
        }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindFirstObjectByType(typeof(T)) as T;
#if UNITY_EDITOR
                    if (instance == null)
                    {
                        Debug.LogErrorFormat("Singleton<T>: Could not find GameObject of type " + typeof(T).Name +
                                             " in scene");
                    }
#endif
                }
                return instance;
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}