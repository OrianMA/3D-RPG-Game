using System;
using UnityEngine;

namespace BaseTemplate.Behaviours
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T s_Instance;
        private static readonly object s_Lock = new object();

        public static T Instance
        {
            get
            {
                lock (s_Lock)
                {
                    if (s_Instance == null)
                    {
                        UnityEngine.Object[] instances = FindObjectsOfType(typeof(T));

                        if (instances.Length > 1)
                        {
                            Debug.LogWarning("MULTIPLE instances of \"" + typeof(T).Name + "\" in the scene");
                        }

                        if (instances == null || instances.Length == 0)
                        {
                            Debug.LogWarning("NO instance found for the type \"" + typeof(T).Name + "\"");
                            return null;
                        }

                        s_Instance = (T)instances[0];
                    }

                    return s_Instance;
                }
            }
        }
    }
}