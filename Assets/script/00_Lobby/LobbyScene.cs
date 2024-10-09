using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    private CanvasScaler canvasScaler;
    private void Awake()
    {
        // PlayerPrefs.DeleteKey("PlayerData");

        //데이터 불러오기
        if (!PlayerData.Instance.LoadData())
        {
            // 실패하면 게임 끄기
            Application.Quit();
        }

        // 로비 씬 해상도 설정
        LobbySetResolution();
    }

    public void LobbySetResolution()
    {
        canvasScaler = FindObjectOfType<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        // 화면 길이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // 화면 높이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);

        Debug.Log(ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_WIDTH));
        Debug.Log(ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_HEIGHT));
    }
}
