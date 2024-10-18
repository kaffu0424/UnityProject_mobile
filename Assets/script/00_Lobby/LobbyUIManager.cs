using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyUIManager : Singleton_Mono<LobbyUIManager>
{
    [SerializeField] private LobbyPopup     m_popupUI;      // �˾�
    [SerializeField] private LobbyPlayPopup m_playUI;       // �÷��� UI
    [SerializeField] private LobbyUpgrade   m_upgradeUI;    // ���׷��̵� UI
    [SerializeField] private LobbyOption    m_optionUI;     // �ɼ� UI
    [SerializeField] private LobbyErrorUI   m_errorUI;      // ���� UI

    // Get / Set
    public LobbyPopup       popupUI     { get { return m_popupUI; } }
    public LobbyPlayPopup   playUI      { get { return m_playUI; } }
    public LobbyUpgrade     upgradeUI   { get { return m_upgradeUI; } }
    public LobbyOption      optionUI    { get { return m_optionUI; } }
    public LobbyErrorUI     errorUI     {  get { return m_errorUI; } }

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
    public void OnErrorMessage(string _text, float _time = 0.5f)
    {
        // �ð� �⺻�� 0.5��
        // �� ��� ����ϰ������ �Ű������� �߰����ֱ�

        m_errorUI.gameObject.SetActive(true);
        StartCoroutine(m_errorUI.OnMessage(_text, _time));
    }
}
