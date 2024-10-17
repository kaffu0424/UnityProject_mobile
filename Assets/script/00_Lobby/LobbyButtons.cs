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
        // 게임 시작 UI  ( 난이도 선택 ) 함수 호출
        LobbyUIManager.Instance.OnPlayPopup(true);
    }
    private void UpgradeButton()
    {
        // 업그레이드 UI 함수 호출
        LobbyUIManager.Instance.OnUpgradePopup(true);
        
    }
    private void OptionButton()
    {
        // 옵션 UI 함수 호출
        LobbyUIManager.Instance.OnOptionPopup(true);
    }
    private void ExitButton()
    {
        // 종료 UI 함수 호출 ( 팝업 )
        LobbyUIManager.Instance.OnPopup(true);

        // 한글
        if(PlayerData.Instance.data.localization == LocalizationType.KOR)
            LobbyUIManager.Instance.popupUI.SetText("종료하기", "종료하시겠습니까?");
        // 영어
        else
            LobbyUIManager.Instance.popupUI.SetText("EXIT", "EXIT GAME?");

        LobbyUIManager.Instance.popupUI.SetButtonFunction(() => { Application.Quit(); });
    }
}
