using UnityEngine;
using UnityEngine.UI;

public class MyItems : MonoBehaviour
{
    // Prefab
    [SerializeField] private GameObject m_slotObject;

    // rectTrasnform
    [SerializeField] private RectTransform m_rectMYitems;
    [SerializeField] private RectTransform m_rectInventory;
    [SerializeField] private RectTransform m_rectChest;

    // GridLayoutGroup
    [SerializeField] private GridLayoutGroup m_inventoryLayout;
    [SerializeField] private GridLayoutGroup m_chestLayout;

    private void Start()
    {
        // RectTransform
        m_rectMYitems       = GetComponent<RectTransform>();

        // m_chestLayout
        m_inventoryLayout   = m_rectInventory.GetComponent<GridLayoutGroup>();
        m_chestLayout       = m_rectChest.GetComponent<GridLayoutGroup>();

        // �κ��丮 / â�� UI �ػ� ����
        ResolutionUI();
    }

    /// <summary>
    /// â�� / �κ��丮 ������ �ػ� ������ ���� �Լ�
    /// </summary>
    private void ResolutionUI()
    {
        // Chest + inventory UI����
        float uiHeight = ResolutionData.Instance.GetData(RESOLUTION_DATA.UIRECT_HEIGHT);
        float itemsHeight = uiHeight * (m_rectMYitems.anchorMax.y - m_rectMYitems.anchorMin.y);

        // SlotSize ����ϱ� ( Inventory UI ���� ) ;
        float inventoryWidth = ResolutionData.Instance.GetData(RESOLUTION_DATA.UIRECT_WIDTH);
        float inventoryHeight = itemsHeight * (m_rectInventory.anchorMax.y - m_rectInventory.anchorMin.y);

        float i_slotSize_width = (inventoryWidth * 0.85f) / 5;
        float i_slotSize_height = (inventoryHeight * 0.85f) / 5;

        // SlotSize ����ϱ� ( Chest UI ���� ) ;
        float chestWidth = ResolutionData.Instance.GetData(RESOLUTION_DATA.UIRECT_WIDTH);
        float chestHeight = itemsHeight * (m_rectChest.anchorMax.y - m_rectChest.anchorMin.y);

        float c_slotSize_width    = (chestWidth * 0.85f) / 6;
        float c_slotSize_height   = (chestHeight * 0.9f) / 2;

        // Size ����
        // inventory �� chest �������� ������ ������ ��������
        // ���� ���� ����� �������� ������ ����
        float i_slotSize = i_slotSize_width < i_slotSize_height ? i_slotSize_width : i_slotSize_height; // �κ��丮 ���� ������ 
        float c_slotSize = c_slotSize_width < c_slotSize_height ? c_slotSize_width : c_slotSize_height; // â�� ���� ������
        float slotSize = i_slotSize < c_slotSize ? i_slotSize : c_slotSize;

        m_chestLayout.cellSize = new Vector2(slotSize, slotSize);
        m_inventoryLayout.cellSize = new Vector2(slotSize, slotSize);

        // inventory UI ���� ���� ( 5 * 5 )
        for(int i = 0; i < 25; i++)
        {
            Instantiate(m_slotObject, m_rectInventory);
        }

        // chest UI ���� ���� ( 6 * 2 )
        for (int i = 0; i < 12; i++)
        {
            Instantiate(m_slotObject, m_rectChest);
        }

        // 6*2
        // 413 * 0.9 = 371.7 ( �� �߰� �Ʒ� ���� �� ���� ������ ���̱�)
        // ���Ʒ��� ���� ������ 10
        // 371 / 2 = 185.85
        // ���� ������� 185.85;
    }
}
