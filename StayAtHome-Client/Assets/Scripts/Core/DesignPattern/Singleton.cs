using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.DesignPattern
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        private protected virtual void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = (T)this;
        }

        private protected virtual void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}