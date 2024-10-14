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
        // �κ�� �Ŵ��� �ʱ�ȭ ( �̱��� XX )
        InitManagers();

        // ���� ������ �ε�
        LoadData();

        // �κ� �� �ػ� ����
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
        // ������ �ʱ�ȭ
        // �÷��̾� �����Ϳ� ���� �߰��ɶ����� �ѹ� ��������ֱ�!
        // PlayerPrefs.DeleteKey("PlayerData");

        //������ �ҷ�����
        if (!PlayerData.Instance.LoadData())
        {
            // �����ϸ� ���� ����
            Application.Quit();
        }
    }

    private void LobbySetResolution()
    {
        FindObjectOfType<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);

        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);
    }
}

