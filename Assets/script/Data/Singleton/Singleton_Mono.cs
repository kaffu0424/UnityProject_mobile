using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton_Mono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
            }
            return instance;
        }
    }

    private void Awake()
    {
        InitializeManager();
    }

    protected abstract void InitializeManager();
}