using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    private LobbyButtonManager  m_buttonManager;
    private LobbyUIManager      m_uiManager;
    private LobbyEventManager   m_eventManager;

    public LobbyButtonManager   buttonManager   { get { return m_buttonManager; } }
    public LobbyUIManager       uiManager       { get { return m_uiManager; } }
    public LobbyEventManager    eventManager    { get { return m_eventManager; } }

    private void Awake()
    {
        // 로비씬 매니저 초기화 ( 싱글톤 XX )
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
        m_eventManager  = GetComponentInChildren<LobbyEventManager>();

        m_buttonManager.lobbyScene  = this;
        m_uiManager.lobbyScene      = this;
        m_eventManager.lobbyScene   = this;
    }

    private void LoadData()
    {
        // 데이터 초기화
        // 플레이어 데이터에 뭔가 추가될때마다 한번 실행시켜주기!
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
    }
}

