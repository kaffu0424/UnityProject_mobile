using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyUIManager : MonoBehaviour
{
    private LobbyScene m_Lobby;
    public LobbyScene lobbyScene { get { return m_Lobby; } set { m_Lobby = value; } }

    [SerializeField] private LobbyPopup m_popupUI;
    public LobbyPopup popupUI { get {  return m_popupUI; } }

    [SerializeField] private GameObject m_playUI;
    [SerializeField] private GameObject m_upgradeUI;
    [SerializeField] private GameObject m_optionUI;

    public void OnPlayPopup()
    {
        m_playUI.SetActive(true);
    }

    public void OnUpgradePopup()
    {
        m_upgradeUI.SetActive(true);
    }
    public void OnOptionPopup()
    {
        m_optionUI.SetActive(true);
    }
    public void OnExitPopup()
    {
        m_popupUI.gameObject.SetActive(true);
        m_popupUI.SetText("종료하기", "종료하시겠습니까?");
    }
}
