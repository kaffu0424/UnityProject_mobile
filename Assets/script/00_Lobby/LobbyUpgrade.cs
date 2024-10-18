using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum UPGRADE_TYPE
{
    // ����
    MaxHP,              // �߰� ü��
    Damage,             // ������
    AttackSpeed,        // ���ݼӵ�
    Critical,           // ũȮ �� ũ��

    // ��ƿ
    Coin,               // ���� ��� ����
    Slot,               // ���� ����
}

public class LobbyUpgrade : MonoBehaviour
{
    private GridLayoutGroup m_slotLayout;
    private RectTransform   m_rectTransform;
    private Button          m_backButton;

    // add Inspector
    [SerializeField] private GameObject m_slotPrefab;

    // ���� ����
    private List<LobbyUpgradeSlot> m_upgradeSlots;
    private void Start()
    {
        // ���� �ʱ�ȭ
        m_slotLayout    = GetComponentInChildren<GridLayoutGroup>();
        m_rectTransform = GetComponent<RectTransform>();
        m_backButton    = GetComponentInChildren<Button>();

        // ��ư �̺�Ʈ ���ε�
        m_backButton.onClick.AddListener(()=> BackButtonFunction());

        // ���׷��̵� UI ���� ������
        float width = ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_WIDTH);
        ResizeSlot(width);

        // ���� ����
        CreateSlots();

        // ���� ���� ������Ʈ
        UpdateSlots();
    }
    private void OnEnable()
    {
        UpdateSlots();
    }

    private void ResizeSlot(float _width)
    {
        // ���׷��̵� UI ��Ŀ ����
        float x_min = m_rectTransform.anchorMin.x;
        float x_max = m_rectTransform.anchorMax.x;

        // ���׷��̵� UI width
        int width = (int)(_width * Math.Abs(x_min - x_max));

        // 1�ٿ� 4�� �� ��ġ�Ҽ� �ִ� ���� ������
        int slotSize = width / 4;

        // ���� ����� n*n���� 
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
