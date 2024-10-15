using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class LobbyUpgradeSlot : MonoBehaviour, IPointerClickHandler
{
    private UPGRADE_TYPE m_upgradeType;
    public UPGRADE_TYPE upgradeType
    { get { return m_upgradeType; } set { m_upgradeType = value; } }

    [SerializeField] private TextMeshProUGUI m_skillLevelText;

    public void UpdateData()
    {
        m_skillLevelText.text =
            "LV. " + PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // ���׷��̵� �̹��� Ŭ�� �̺�Ʈ

        LobbyUIManager.Instance.OnPopup(true);

        string title = "���׷��̵�";
        string description = 
            m_upgradeType.ToString() + 
            "\n 10 -> 20 " +
            "\n �Ҹ���ȭ : 10";
        LobbyUIManager.Instance.popupUI.SetText(title, description);

        Action func = () => UpgradeFunction();
        LobbyUIManager.Instance.popupUI.SetButtonFunction(func);
    }

    private void UpgradeFunction()
    {
        Debug.Log(m_upgradeType.ToString());

        PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]++; // ��ġ ����
        PlayerData.Instance.SaveData();                             // ����

        UpdateData();                                               // ���� ������Ʈ
                
        LobbyUIManager.Instance.OnPopup(false);                     // �˾� �ݱ�
    }
}
