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
        m_popupUI.SetData("���׷��̵�", "�̰� ���׷��̵�?");
    }
    public void OnOptionPopup()
    {
        m_popupUI.gameObject.SetActive(true);
        m_popupUI.SetData("�ɼ�", "�̰� �ɼ���");
    }
    public void OnExitPopup()
    {
        //UnityAction a = () => { Debug.Log("����"); };
        m_popupUI.gameObject.SetActive(true);
        m_popupUI.SetData("�����ϱ�", "�����Ͻðڽ��ϱ�?");
    }
}
