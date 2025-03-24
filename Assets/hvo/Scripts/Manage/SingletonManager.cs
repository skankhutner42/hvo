using System;
using UnityEngine;

namespace hvo.Scripts.Manage
{
    public abstract class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected virtual void Awake()
        {
            T[] managers = FindObjectsByType<T>(FindObjectsSortMode.None);
            if (managers.Length > 1)
            { 
                Destroy(gameObject);
                return;
            }
        }

        public static T Get()
        {
            var tag = typeof(T).Name;

            GameObject managerObject = UnityEngine.GameObject.FindWithTag(tag);
            if (managerObject != null)
            {
                return managerObject.GetComponent<T>();
            }

            GameObject go = new(tag);
            go.tag = tag;
            return go.GetComponent<T>();
        }
    }
}