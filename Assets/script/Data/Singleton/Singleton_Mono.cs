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
                    // ������Ʈ�� �����ʿ�������.. ?
                    // ������Ʈ�� ����������� ���װ� ���Գ��Ű�����
                    // �׳� ���� ��������ȵǳ�?
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