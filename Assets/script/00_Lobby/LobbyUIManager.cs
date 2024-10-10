using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyUIManager : MonoBehaviour
{
    private LobbyScene m_Lobby;
    public LobbyScene lobbyScene { get { return m_Lobby; } set { m_Lobby = value; } }

    [SerializeField] private LobbyPopup m_popupUI;
    public void OnUpgradePopup()
    {
        m_popupUI.gameObject.SetActive(true);
        m_popupUI.SetData("업그레이드", "이건 업그레이드?");
    }
    public void OnOptionPopup()
    {
        m_popupUI.gameObject.SetActive(true);
        m_popupUI.SetData("옵션", "이건 옵션임");
    }
    public void OnExitPopup()
    {
        //UnityAction a = () => { Debug.Log("종료"); };
        m_popupUI.gameObject.SetActive(true);
        m_popupUI.SetData("종료하기", "종료하시겠습니까?");
    }
}
