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

                if (instance == null)
                {
                    // 오브젝트르 만들필요있을까.. ?
                    // 오브젝트가 사라진정도면 버그가 씨게난거같은데
                    // 그냥 게임 꺼버리면안되나?
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));     
                    instance = obj.GetComponent<T>();
                }
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