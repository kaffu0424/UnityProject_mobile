using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    private LobbyButtonManager  m_buttonManager;
    private LobbyUIManager      m_uiManager;

    public LobbyButtonManager   buttonManager { get { return m_buttonManager; } }
    public LobbyUIManager       uiManager { get { return m_uiManager; } }

    private void Awake()
    {
        InitManagers();

        // 로컬 데이터 로드
        LoadData();

        // 로비 씬 해상도 설정
        LobbySetResolution();
    }

    private void InitManagers()
    {
        m_buttonManager = GetComponentInChildren<LobbyButtonManager>();
        m_uiManager     = GetComponentInChildren<LobbyUIManager>();

        m_buttonManager.lobbyScene  = this;
        m_uiManager.lobbyScene      = this;
    }

    private void LoadData()
    {
        // PlayerPrefs.DeleteKey("PlayerData");

        //데이터 불러오기
        if (!PlayerData.Instance.LoadData())
        {
            // 실패하면 게임 끄기
            Application.Quit();
        }
    }

    private void LobbySetResolution()
    {
        FindObjectOfType<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);

        // 화면 길이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // 화면 높이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);

        Debug.Log(ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_WIDTH));
        Debug.Log(ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_HEIGHT));
    }
}
