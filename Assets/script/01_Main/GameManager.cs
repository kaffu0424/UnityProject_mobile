using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton_Mono<GameManager>
{
    public Camera gameCamera;               // 테스트
    public List<GameObject> testObjects;    // 테스트
    protected override void InitializeManager()
    {
        { 
            Vector3 pos1 = gameCamera.WorldToViewportPoint(testObjects[0].transform.position);
            pos1.x = 0; pos1.y = 0;
            testObjects[0].transform.position = gameCamera.ViewportToWorldPoint(pos1);
        }
        {
            Vector3 pos1 = gameCamera.WorldToViewportPoint(testObjects[1].transform.position);
            pos1.x = 0; pos1.y = 1;
            testObjects[1].transform.position = gameCamera.ViewportToWorldPoint(pos1);
        }
        {
            Vector3 pos1 = gameCamera.WorldToViewportPoint(testObjects[2].transform.position);
            pos1.x = 1; pos1.y = 1;
            testObjects[2].transform.position = gameCamera.ViewportToWorldPoint(pos1);
        }
        {
            Vector3 pos1 = gameCamera.WorldToViewportPoint(testObjects[3].transform.position);
            pos1.x = 1; pos1.y = 0;
            testObjects[3].transform.position = gameCamera.ViewportToWorldPoint(pos1);
        }
    }

    private void Update()
    {

    }
}
