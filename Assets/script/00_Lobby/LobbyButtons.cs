using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum LobbyButtonType
{
    LOBBY_PLAY,
    LOBBY_UPGRADE,
    LOBBY_OPTION,
    LOBBY_EXIT,
}

public class LobbyButtons : MonoBehaviour
{
    [SerializeField] private List<Button> m_lobbyButtons;

    private void Start()
    {
        m_lobbyButtons[(int)LobbyButtonType.LOBBY_PLAY].onClick.AddListener(() => PlayButton());
        m_lobbyButtons[(int)LobbyButtonType.LOBBY_UPGRADE].onClick.AddListener(() => UpgradeButton());
        m_lobbyButtons[(int)LobbyButtonType.LOBBY_OPTION].onClick.AddListener(() => OptionButton());
        m_lobbyButtons[(int)LobbyButtonType.LOBBY_EXIT].onClick.AddListener(() => ExitButton());
    }

    private void PlayButton()
    {
        // ���� ���� UI  ( ���̵� ���� ) �Լ� ȣ��
        LobbyUIManager.Instance.OnPlayPopup(true);
    }
    private void UpgradeButton()
    {
        // ���׷��̵� UI �Լ� ȣ��
        LobbyUIManager.Instance.OnUpgradePopup(true);
        
    }
    private void OptionButton()
    {
        // �ɼ� UI �Լ� ȣ��
        LobbyUIManager.Instance.OnOptionPopup(true);
    }
    private void ExitButton()
    {
        // ���� UI �Լ� ȣ�� ( �˾� )
        LobbyUIManager.Instance.OnPopup(true);

        LobbyUIManager.Instance.popupUI.SetText("�����ϱ�", "�����Ͻðڽ��ϱ�?");
        LobbyUIManager.Instance.popupUI.SetButtonFunction(() => { Application.Quit(); });
    }
}
