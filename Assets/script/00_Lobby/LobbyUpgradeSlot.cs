using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class LobbyUpgradeSlot : MonoBehaviour, IPointerClickHandler
{
    const int defaultCost = 50;

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
        // ���׷��̵� �˾� Ȱ��ȭ
        LobbyUIManager.Instance.OnPopup(true);

        // ���׷��̵� �˾� ���� ä���
        string title, description;
        if (PlayerData.Instance.data.localization == LocalizationType.KOR)
            SetUpgradePopupKOR(out title, out description);
        else
            SetUpgradePopupENG(out title, out description);
        LobbyUIManager.Instance.popupUI.SetText(title, description);

        // ���׷��̵� ��ư �̺�Ʈ ���ε�
        Action func = () => UpgradeFunction();
        LobbyUIManager.Instance.popupUI.SetButtonFunction(func);
    }

    private void SetUpgradePopupKOR(out string _title, out string _description)
    {
        string key = Localization.Instance.GetKORString(m_upgradeType.ToString());
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "���׷��̵�";
        _description = $"\n{key} \n {currentLevel} -> {currentLevel} \n ��� : {defaultCost}\n\n";
    }

    private void SetUpgradePopupENG(out string _title, out string _description)
    {
        string key = m_upgradeType.ToString();
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "UPGRADE";
        _description = $"\n{key} \n Lv.{currentLevel} -> Lv.{currentLevel + 1} \n Cost : {defaultCost}\n\n";
    }

    private void UpgradeFunction()
    {
        PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]++; // ��ġ ����
        PlayerData.Instance.SaveData();                             // ����

        UpdateData();                                               // ���� ������Ʈ
                
        LobbyUIManager.Instance.OnPopup(false);                     // �˾� �ݱ�
    }
}
