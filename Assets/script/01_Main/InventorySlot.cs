using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private RectTransform m_rect;
    [SerializeField] private int m_index;
    [SerializeField] private SlotType m_slotType;

    [SerializeField] private TextMeshProUGUI t;
    public int index { get { return m_index; } set { m_index = value; } }
    public SlotType slotType { get { return m_slotType; } set { m_slotType = value; } }

    private void Start()
    {
        m_rect = GetComponent<RectTransform>();

    }

    public void test()
    {
        // Colume ªÁ¿Ã¡Ó 
        int iColSize = iColSize = InventoryManager.Instance.inventoryColumeSize;
        if (slotType == SlotType.Chest)
            iColSize = InventoryManager.Instance.chestColumeSize;

        // text
        string col = $"{index / iColSize}";
        string row = $"{index % iColSize}";
        t.text = $" {col},{row} ";
    }
}
