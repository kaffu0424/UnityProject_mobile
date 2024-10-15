using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyUIManager : Singleton_Mono<LobbyUIManager>
{
    [SerializeField] private LobbyPopup     m_popupUI;      // 팝업
    [SerializeField] private LobbyPlayPopup m_playUI;       // 플레이 UI
    [SerializeField] private LobbyUpgrade   m_upgradeUI;    // 업그레이드 UI
    [SerializeField] private LobbyOption    m_optionUI;     // 옵션 UI

    // Get / Set
    public LobbyPopup       popupUI     { get { return m_popupUI; } }
    public LobbyPlayPopup   playUI      { get { return m_playUI; } }
    public LobbyUpgrade     upgradeUI   { get { return m_upgradeUI; } }
    public LobbyOption      optionUI    { get { return m_optionUI; } }

    protected override void InitializeManager()
    {

    }

    public void OnPlayPopup(bool _state)
    {
        m_playUI.gameObject.SetActive(_state);
    }

    public void OnUpgradePopup(bool _state)
    {
        m_upgradeUI.gameObject.SetActive(_state);
    }
    public void OnOptionPopup(bool _state)
    {
        m_optionUI.gameObject.SetActive(_state);
    }
    public void OnPopup(bool _state)
    {
        m_popupUI.gameObject.SetActive(_state);
    }
}
