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
        // 업그레이드 팝업 활성화
        LobbyUIManager.Instance.OnPopup(true);

        // 업그레이드 팝업 내용 채우기
        string title, description;
        if (PlayerData.Instance.data.localization == LocalizationType.KOR)
            SetUpgradePopupKOR(out title, out description);
        else
            SetUpgradePopupENG(out title, out description);
        LobbyUIManager.Instance.popupUI.SetText(title, description);

        // 업그레이드 버튼 이벤트 바인딩
        Action func = () => UpgradeFunction();
        LobbyUIManager.Instance.popupUI.SetButtonFunction(func);
    }

    private void SetUpgradePopupKOR(out string _title, out string _description)
    {
        string key = Localization.Instance.GetKORString(m_upgradeType.ToString());
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "업그레이드";
        _description = $"\n{key} \n {currentLevel} -> {currentLevel} \n 비용 : {defaultCost}\n\n";
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
        PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]++; // 수치 증가
        PlayerData.Instance.SaveData();                             // 저장

        UpdateData();                                               // 슬롯 업데이트
                
        LobbyUIManager.Instance.OnPopup(false);                     // 팝업 닫기
    }
}
