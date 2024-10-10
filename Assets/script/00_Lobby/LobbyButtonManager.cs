using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum LobbyButton
{
    LOBBY_PLAY,
    LOBBY_UPGRADE,
    LOBBY_OPTION,
    LOBBY_EXIT,
}

public class LobbyButtonManager : MonoBehaviour
{
    private LobbyScene m_Lobby;
    public LobbyScene lobbyScene { get { return m_Lobby; } set { m_Lobby = value; } }

    [SerializeField] private List<Button> m_lobbyButtons;

    private void Start()
    {
        m_lobbyButtons[(int)LobbyButton.LOBBY_PLAY].onClick.AddListener(() => PlayButton());
        m_lobbyButtons[(int)LobbyButton.LOBBY_UPGRADE].onClick.AddListener(() => UpgradeButton());
        m_lobbyButtons[(int)LobbyButton.LOBBY_OPTION].onClick.AddListener(() => OptionButton());
        m_lobbyButtons[(int)LobbyButton.LOBBY_EXIT].onClick.AddListener(() => ExitButton());
    }

    private void PlayButton()
    {
        // ���� ����
        SceneManager.LoadScene(1);
    }

    private void UpgradeButton()
    {
        // 1. ���׷��̵� �˾�
    }
    private void OptionButton()
    {
        // 1. �ɼ� �˾�
    }
    private void ExitButton()
    {
        lobbyScene.uiManager.OnExitPopup();
        // 1. ���� �˾� ����
        // 2. yes : ���� ����
        // 3. no : �˾� �ݱ�
    }
}
