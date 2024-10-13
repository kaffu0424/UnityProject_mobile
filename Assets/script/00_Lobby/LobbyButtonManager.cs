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
    LOBBY_POPUP_YES,
    LOBBY_POPUP_NO
}

public class LobbyButtonManager : MonoBehaviour
{
    private LobbyScene m_Lobby;
    public LobbyScene lobbyScene { get { return m_Lobby; } set { m_Lobby = value; } }

    [SerializeField] private List<Button> m_lobbyButtons;
    [SerializeField] private Button m_popupYESButton;
    [SerializeField] private Button m_popupNOButton;

    private void Start()
    {
        m_lobbyButtons[(int)LobbyButton.LOBBY_PLAY].onClick.AddListener(() => PlayButton());
        m_lobbyButtons[(int)LobbyButton.LOBBY_UPGRADE].onClick.AddListener(() => UpgradeButton());
        m_lobbyButtons[(int)LobbyButton.LOBBY_OPTION].onClick.AddListener(() => OptionButton());
        m_lobbyButtons[(int)LobbyButton.LOBBY_EXIT].onClick.AddListener(() => ExitButton());
    }

    private void PlayButton()
    {
        // ���� ���� UI  ( ���̵� ���� ) �Լ� ȣ��
        lobbyScene.uiManager.OnPlayPopup();
    }
    private void UpgradeButton()
    {
        // ���׷��̵� UI �Լ� ȣ��
        lobbyScene.uiManager.OnUpgradePopup();
    }
    private void OptionButton()
    {
        // �ɼ� UI �Լ� ȣ��
        lobbyScene.uiManager.OnOptionPopup();
    }
    private void ExitButton()
    {
        // ���� UI �Լ� ȣ��
        lobbyScene.uiManager.OnExitPopup();
    }
}
