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
    // 변수
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
        // 텍스트 업데이트
        m_skillLevelText.text = "LV. " + level;

        // 슬롯의 이미지가 비어있을때 채워주기
        m_skillImage.sprite = ResourceData.Instance.GetSprite(spriteName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 업그레이드 팝업 활성화
        LobbyUIManager.Instance.OnPopup(true);

        // 업그레이드 팝업 내용 채우기
        // Localization을 활용할수있을때 바꿔야징~
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

    private void UpgradeFunction()
    {
        if(PlayerData.Instance.data.cost >= cost)
        {
            PlayerData.Instance.data.cost -= cost;                      // Cost 감소
            PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType]++; // 수치 증가
            PlayerData.Instance.SaveData();                             // 저장
            UpdateSlot();                                               // 슬롯 업데이트
        }
        else
        {
            // 경고 메세지 출력
            if (PlayerData.Instance.data.localization == LocalizationType.KOR)
                LobbyUIManager.Instance.OnErrorMessage("코인이 부족합니다.");
            else
                LobbyUIManager.Instance.OnErrorMessage("you don't have enough coin.");
        }
        LobbyUIManager.Instance.OnPopup(false);                     // 팝업 닫기
    }


    private void SetUpgradePopupKOR(out string _title, out string _description)
    {
        string key = Localization.Instance.GetKORString(m_upgradeType.ToString());
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "업그레이드";
        _description = $"\n{key} \n {currentLevel} -> {currentLevel + 1} \n 비용 : {cost}\n\n";
    }

    private void SetUpgradePopupENG(out string _title, out string _description)
    {
        string key = m_upgradeType.ToString();
        int currentLevel = PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];

        _title = "UPGRADE";
        _description = $"\n{key} \n Lv.{currentLevel} -> Lv.{currentLevel + 1} \n Cost : {cost}\n\n";
    }
}
