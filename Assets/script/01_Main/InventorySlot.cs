using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private RectTransform   m_rect;
    private Image           m_image;

    // 데이터 확인하기 위해 인스펙터창에 노출
    [SerializeField] private ItemPos    m_pos;          // 위치 값
    [SerializeField] private ItemObject m_item;         // 해당 위치에 있는 아이템
    [SerializeField] private SlotType   m_slotType;     // 슬롯의 타입

    // get / set
    public ref ItemPos pos { get { return ref m_pos; } }
    public ItemObject item { get { return m_item; }  set { m_item = value; } }
    public SlotType slotType { get { return m_slotType; } }


    public void InitSlot(int _cnt, SlotType _type)
    {
        gameObject.name = "slot";

        // GetComponent
        m_rect = GetComponent<RectTransform>();
        m_image = GetComponent<Image>();

        // Init
        item = null;
        m_slotType = _type;

        // 배열 첫번째 0,0 일때 예외처리
        if(_cnt == 0)
        {
            m_pos.y = 0;
            m_pos.x = 0;
        }
        else
        {
            m_pos.y = _cnt / 5;
            m_pos.x = _cnt % 5;
        }

        //InventoryManager의 Slot 배열에 타입에 맞게 저장
        if (slotType == SlotType.Inventory)
            InventoryManager.Instance.inventorySlots[m_pos.y, m_pos.x] = this;
        else
            InventoryManager.Instance.chestSlots[m_pos.y, m_pos.x] = this;
    }
}
