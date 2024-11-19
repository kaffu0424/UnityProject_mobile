using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private RectTransform   m_rect;
    private Image           m_image;

    // ������ Ȯ���ϱ� ���� �ν�����â�� ����
    [SerializeField] private ItemPos    m_pos;          // ��ġ ��
    [SerializeField] private ItemObject m_item;         // �ش� ��ġ�� �ִ� ������
    [SerializeField] private SlotType   m_slotType;     // ������ Ÿ��

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

        // �迭 ù��° 0,0 �϶� ����ó��
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

        //InventoryManager�� Slot �迭�� Ÿ�Կ� �°� ����
        if (slotType == SlotType.Inventory)
            InventoryManager.Instance.inventorySlots[m_pos.y, m_pos.x] = this;
        else
            InventoryManager.Instance.chestSlots[m_pos.y, m_pos.x] = this;
    }
}
