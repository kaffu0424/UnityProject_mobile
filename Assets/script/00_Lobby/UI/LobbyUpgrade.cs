using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum UPGRADE_TYPE
{
    // 버프
    MaxHP,              // 체력 수치 증가
    Damage,             // 데미지 수치 증가
    AttackSpeed,        // 공격속도
    Critical,           // 크확 및 크뎀
    Defense,            // 방어력

    // 디버프
    Slow,               // 몬스터 속도감소 (이속 공속)

    // 유틸
    Coin,               // 시작 비용 증가
    Slot,               // 슬롯 증가
    Lucky,               // 운빨 증가
}

public class LobbyUpgrade : MonoBehaviour
{
    private GridLayoutGroup m_slotLayout;
    private RectTransform   m_rectTransform;
    private Button          m_backButton;

    // add Inspector
    [SerializeField] private GameObject m_slotPrefab;

    // 슬롯 참조
    private List<LobbyUpgradeSlot> m_upgradeSlots;
    private void Start()
    {
        // 변수 초기화
        m_slotLayout    = GetComponentInChildren<GridLayoutGroup>();
        m_rectTransform = GetComponent<RectTransform>();
        m_backButton    = GetComponentInChildren<Button>();

        // 버튼 이벤트 바인딩
        m_backButton.onClick.AddListener(()=> BackButtonFunction());

        // 업그레이드 UI 슬롯 사이즈
        float width = ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_WIDTH);
        ResizeSlot(width);

        // 슬롯 생성
        CreateSlots();

        // 슬롯 정보 업데이트
        UpdateSlots();
    }
    private void OnEnable()
    {
        // Lobby씬이 실행되었을때 처음으로 업그레이드UI 켜졌을때
        // Slot이 없어서 오류 뜸! 무시해도됨

        // OnEnable이 Start보다 먼저 실행되기때문에 발생하는 오류인듯!
        UpdateSlots();
    }

    private void ResizeSlot(float _width)
    {
        // 업그레이드 UI 앵커 비율
        float x_min = m_rectTransform.anchorMin.x;
        float x_max = m_rectTransform.anchorMax.x;

        // 업그레이드 UI width
        int width = (int)(_width * Math.Abs(x_min - x_max));

        // 1줄에 4개 를 배치할수 있는 슬롯 사이즈
        int slotSize = width / 4;

        // 슬롯 사이즈를 n*n으로 
        m_slotLayout.cellSize = new Vector2(slotSize, slotSize);
    }

    private void CreateSlots()
    {
        m_upgradeSlots = new List<LobbyUpgradeSlot>();

        int slotCount = PlayerData.Instance.data.upgradeInfo.Count;

        for(int i = 0; i < slotCount; i++)
        {
            LobbyUpgradeSlot slot = 
                Instantiate(m_slotPrefab, m_slotLayout.transform).GetComponent<LobbyUpgradeSlot>();

            slot.upgradeType = (UPGRADE_TYPE)i;
            m_upgradeSlots.Add(slot);
        }
    }

    public void UpdateSlots()
    {
        for(int i = 0; i < m_upgradeSlots.Count; i++)
        {
            m_upgradeSlots[i].UpdateSlot();
        }
    }

    private void BackButtonFunction()
    {
        gameObject.SetActive(false);
    }
}
