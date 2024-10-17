using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        // ���׷��̵� Ŭ�� �̺�Ʈ
        LobbyUIManager.Instance.OnPopup(true);

        string title, description;
        if (PlayerData.Instance.data.localization == LocalizationType.KOR)
            SetUpgradePopupKOR(out title, out description);
        else
            SetUpgradePopupENG(out title, out description);

        LobbyUIManager.Instance.popupUI.SetText(title, description);

        Action func = () => UpgradeFunction();
        LobbyUIManager.Instance.popupUI.SetButtonFunction(func);
    }

    private void SetUpgradePopupKOR(out string _title, out string _description)
    {
        _title = "���׷��̵�";
        _description =
            m_upgradeType.ToString() +
            "\n 10 -> 20 " +
            "\n �Ҹ���ȭ : 10";
    }
    private void SetUpgradePopupENG(out string _title, out string _description)
    {
        _title = "UPGRADE";
        _description =
            m_upgradeType.ToString() +
            "\n 10 -> 20 " +
            "\n �Ҹ���ȭ : 10";
    }

    private void UpgradeFunction()
    {
        PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]++; // ��ġ ����
        PlayerData.Instance.SaveData();                             // ����

        UpdateData();                                               // ���� ������Ʈ
                
        LobbyUIManager.Instance.OnPopup(false);                     // �˾� �ݱ�
    }
}
