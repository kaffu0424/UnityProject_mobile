using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private RectTransform m_rect;
    [SerializeField] private int m_index;
    [SerializeField] private SlotType m_slotType;
    [SerializeField] private int m_X;
    [SerializeField] private int m_Y;

    [SerializeField] private TextMeshProUGUI t;

    // get / set
    public int index { get { return m_index; } set { m_index = value; } }
    public int X { get { return m_X; } set { m_X = value; } }
    public int Y { get { return m_Y; } set { m_Y = value; } }
    public SlotType slotType { get { return m_slotType; } set { m_slotType = value; } }

    private void Start()
    {
        m_rect = GetComponent<RectTransform>();
        InventoryManager.Instance.AddSlot(this);
    }

    public void test()
    { 
        int irowSize = InventoryManager.Instance.inventoryRowSize;
        if (slotType == SlotType.Chest)
            irowSize = InventoryManager.Instance.chestRowSize;

        X = index % irowSize;
        Y = index / irowSize;

        t.text = $" x:{X}, y:{Y} ";

        // x + ( y * rowSize )
    }
}
