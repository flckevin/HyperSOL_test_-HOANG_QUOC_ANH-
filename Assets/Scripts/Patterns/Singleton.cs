using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    var instances = FindObjectsOfType<T>();
                    if (instances.Length > 0)
                    {
                        _instance = instances[0];
                        return _instance;
                    }
                }

                if (_instance == null)
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }
    }
}
