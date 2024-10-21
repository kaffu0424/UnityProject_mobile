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

        // 인벤토리 / 창고 UI 해상도 대응
        ResolutionUI();
    }

    /// <summary>
    /// 창고 / 인벤토리 슬롯의 해상도 대응을 위한 함수
    /// </summary>
    private void ResolutionUI()
    {
        // Chest + inventory UI높이
        float uiHeight = ResolutionData.Instance.GetData(RESOLUTION_DATA.UIRECT_HEIGHT);
        float itemsHeight = uiHeight * (m_rectMYitems.anchorMax.y - m_rectMYitems.anchorMin.y);

        // SlotSize 계산하기 ( Inventory UI 기준 ) ;
        float inventoryWidth = ResolutionData.Instance.GetData(RESOLUTION_DATA.UIRECT_WIDTH);
        float inventoryHeight = itemsHeight * (m_rectInventory.anchorMax.y - m_rectInventory.anchorMin.y);

        float i_slotSize_width = (inventoryWidth * 0.85f) / 5;
        float i_slotSize_height = (inventoryHeight * 0.85f) / 5;

        // SlotSize 계산하기 ( Chest UI 기준 ) ;
        float chestWidth = ResolutionData.Instance.GetData(RESOLUTION_DATA.UIRECT_WIDTH);
        float chestHeight = itemsHeight * (m_rectChest.anchorMax.y - m_rectChest.anchorMin.y);

        float c_slotSize_width    = (chestWidth * 0.85f) / 6;
        float c_slotSize_height   = (chestHeight * 0.9f) / 2;

        // Size 적용
        // inventory 와 chest 기준으로 생성된 사이즈 데이터중
        // 가장 작은 사이즈를 기준으로 사이즈 적용
        float i_slotSize = i_slotSize_width < i_slotSize_height ? i_slotSize_width : i_slotSize_height; // 인벤토리 슬롯 사이즈 
        float c_slotSize = c_slotSize_width < c_slotSize_height ? c_slotSize_width : c_slotSize_height; // 창고 슬롯 사이즈
        float slotSize = i_slotSize < c_slotSize ? i_slotSize : c_slotSize;

        m_chestLayout.cellSize = new Vector2(slotSize, slotSize);
        m_inventoryLayout.cellSize = new Vector2(slotSize, slotSize);

        // inventory UI 슬롯 생성 ( 5 * 5 )
        for(int i = 0; i < 25; i++)
        {
            Instantiate(m_slotObject, m_rectInventory);
        }

        // chest UI 슬롯 생성 ( 6 * 2 )
        for (int i = 0; i < 12; i++)
        {
            Instantiate(m_slotObject, m_rectChest);
        }

        // 6*2
        // 413 * 0.9 = 371.7 ( 위 중간 아래 공백 을 위해 사이즈 줄이기)
        // 위아래옆 사이 공백은 10
        // 371 / 2 = 185.85
        // 슬롯 사이즈는 185.85;
    }
}
