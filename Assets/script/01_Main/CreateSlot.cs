using UnityEngine;
using UnityEngine.UI;

public class CreateSlot : MonoBehaviour
{
    // Prefab
    [SerializeField] private GameObject m_slotObject;

    // rectTrasnform
    private RectTransform m_rectMYitems;
    [SerializeField] private RectTransform m_rectInventory;
    [SerializeField] private RectTransform m_rectChest;

    // GridLayoutGroup
    private GridLayoutGroup m_inventoryLayout;
    private GridLayoutGroup m_chestLayout;

    private void Start()
    {
        // RectTransform
        m_rectMYitems = GetComponent<RectTransform>();

        // m_chestLayout
        m_inventoryLayout = m_rectInventory.GetComponent<GridLayoutGroup>();
        m_chestLayout = m_rectChest.GetComponent<GridLayoutGroup>();

        // 인벤토리 / 창고 UI 해상도 대응 및 슬롯 생성
        ResolutionUI();
    }

    /// <summary>
    /// 창고 / 인벤토리 슬롯의 해상도 대응과 생성 함수
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

        float c_slotSize_width  = (chestWidth * 0.85f) / 6;
        float c_slotSize_height = (chestHeight * 0.9f) / 2;

        // inventory 와 chest 기준으로 생성된 사이즈 데이터중
        // 가장 작은 사이즈를 구하기
        float i_slotSize    = i_slotSize_width < i_slotSize_height ? i_slotSize_width : i_slotSize_height;  // 인벤토리 슬롯 사이즈 
        float c_slotSize    = c_slotSize_width < c_slotSize_height ? c_slotSize_width : c_slotSize_height;  // 창고 슬롯 사이즈
        float slotSize      = i_slotSize < c_slotSize ? i_slotSize : c_slotSize;                            // 비교

        // 인벤토리와 창고 사이즈 적용
        m_chestLayout.cellSize      = new Vector2(slotSize, slotSize);
        m_inventoryLayout.cellSize  = new Vector2(slotSize, slotSize);

        // 데이터 저장
        ResolutionData.Instance.SetData(RESOLUTION_DATA.SLOTSIZE, slotSize);

        // 슬롯 생성
        // inventory UI 슬롯 생성 ( 5 * 5 )
        for (int i = 0; i < InventoryManager.Instance.inventorySize; i++)
        {
            InventorySlot slot = Instantiate(m_slotObject, m_rectInventory).GetComponent<InventorySlot>();
            slot.InitSlot(i, SlotType.Inventory);
        }

        // chest UI 슬롯 생성 ( 5 * 2 )
        for (int i = 0; i < InventoryManager.Instance.chestSize; i++)
        {
            InventorySlot slot = Instantiate(m_slotObject, m_rectChest).GetComponent<InventorySlot>();
            slot.InitSlot(i, SlotType.Chest);
        }
    }
}