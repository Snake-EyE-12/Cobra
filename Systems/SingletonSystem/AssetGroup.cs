using System;
using NaughtyAttributes;
using UnityEngine;

namespace Cobra.DesignPattern
{
    public abstract class AssetGroup<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static string assetName => typeof(T).Name;
        protected static T instance = null;
        
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
                        try
                        {
                            instance = Instantiate(Resources.Load<AssetGroup<T>>(assetName)) as T;
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("Assets Singleton: Unable to load resource [" + assetName + "]!" +
                                           " Asset inaccessible! Make sure asset is within a 'Resources' folder " +
                                           "and named: " + assetName);
                        }
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
