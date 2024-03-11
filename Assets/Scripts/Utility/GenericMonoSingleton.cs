using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Debug.LogError($"{gameObject} is trying to create another instance of the object", gameObject);
                Destroy(gameObject);
            }
        }
    }
}
