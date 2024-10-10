using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton_Mono<GameManager>
{
    public Camera m_gameCamera;               // 테스트
    public List<GameObject> m_testObjects;    // 테스트
    protected override void InitializeManager()
    {
        { 
            Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[0].transform.position);
            pos1.x = 0; pos1.y = 0;
            m_testObjects[0].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        }
        {
            Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[1].transform.position);
            pos1.x = 0; pos1.y = 1;
            m_testObjects[1].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        }
        {
            Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[2].transform.position);
            pos1.x = 1; pos1.y = 1;
            m_testObjects[2].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        }
        {
            Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[3].transform.position);
            pos1.x = 1; pos1.y = 0;
            m_testObjects[3].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        }
    }

    private void Update()
    {

    }
}
