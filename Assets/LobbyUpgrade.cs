using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum UPGRADE_TYPE
{
    DAMAGE,
    HP
}

public class LobbyUpgrade : MonoBehaviour
{
    private GridLayoutGroup m_slotLayout;
    private RectTransform   m_rectTransform;

    [SerializeField] private GameObject m_slotPrefab;
    [SerializeField] private List<LobbyUpgradeSlot> m_upgradeSlots;
    private void Start()
    {
        m_slotLayout    = GetComponentInChildren<GridLayoutGroup>();
        m_rectTransform = GetComponent<RectTransform>();

        float width = ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_WIDTH);
        ResizeSlot(width);

        CreateSlots();
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

            slot.upgradeIndex = (UPGRADE_TYPE)i;
            m_upgradeSlots.Add(slot);
        }

        UpdateSlots();
    }

    public void UpdateSlots()
    {
        for(int i = 0; i < m_upgradeSlots.Count; i++)
        {
            m_upgradeSlots[i].UpdateData();
        }
    }
}
