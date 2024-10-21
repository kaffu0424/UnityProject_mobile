using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LobbyUpgradeSlot : MonoBehaviour, IPointerClickHandler
{
    // ����
    private const int defaultCost = 50;
    private UPGRADE_TYPE m_upgradeType;

    // Get / Set
    public UPGRADE_TYPE upgradeType
    { get { return m_upgradeType; } set { m_upgradeType = value; } }
    private int cost
    { get { return defaultCost; } }
    private int level
    { get { return PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]; } }
    private string spriteName
    { get { return $"SPRITE_{m_upgradeType}"; } }

    // add inspector
    [SerializeField] private TextMeshProUGUI    m_skillLevelText;
    [SerializeField] Image                      m_skillImage;

    public void UpdateSlot()
    {
        // �ؽ�Ʈ ������Ʈ
        m_skillLevelText.text = "LV. " + level;

        // ������ �̹����� ��������� ä���ֱ�
        m_skillImage.sprite = ResourceData.Instance.GetSprite(spriteName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // ���׷��̵� �˾� Ȱ��ȭ
        LobbyUIManager.Instance.OnPopup(true);

        // ���׷��̵� �˾� ���� ä���
        // Localization�� Ȱ���Ҽ������� �ٲ��¡~
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

    private void UpgradeFunction()
    {
        if(PlayerData.Instance.data.cost >= cost)
        {
            PlayerData.Instance.data.cost -= cost;                      // Cost ����
            PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]++; // ��ġ ����
            PlayerData.Instance.SaveData();                             // ����
            UpdateSlot();                                               // ���� ������Ʈ
        }
        else
        {
            // ��� �޼��� ���
            if (PlayerData.Instance.data.localization == LocalizationType.KOR)
                LobbyUIManager.Instance.OnErrorMessage("������ �����մϴ�.");
            else
                LobbyUIManager.Instance.OnErrorMessage("you don't have enough coin.");
        }
        LobbyUIManager.Instance.OnPopup(false);                     // �˾� �ݱ�
    }


    private void SetUpgradePopupKOR(out string _title, out string _description)
    {
        string key = Localization.Instance.GetKORString(m_upgradeType.ToString());
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "���׷��̵�";
        _description = $"\n{key} \n {currentLevel} -> {currentLevel + 1} \n ��� : {cost}\n\n";
    }

    private void SetUpgradePopupENG(out string _title, out string _description)
    {
        string key = m_upgradeType.ToString();
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "UPGRADE";
        _description = $"\n{key} \n Lv.{currentLevel} -> Lv.{currentLevel + 1} \n Cost : {cost}\n\n";
    }
}
