using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private RectTransform m_rect;
    private SlotType m_slotType;

    // 데이터 확인하기 위해 인스펙터창에 노출
    [SerializeField] private int m_X;
    [SerializeField] private int m_Y;

    // get / set
    public int X { get { return m_X; } }
    public int Y { get { return m_Y; } }
    public SlotType slotType { get { return m_slotType; }}
    public RectTransform rect { get { return m_rect; }}

    public void InitSlot(int _cnt, SlotType _type)
    {
        gameObject.name = "slot";

        // GetComponent
        m_rect = GetComponent<RectTransform>();

        // Init
        m_slotType = _type;

        // 배열 첫번째 0,0 일때 예외처리
        if(_cnt == 0)
        {
            m_Y = 0;
            m_X = 0;
        }
        else
        {
            m_Y = _cnt / (int)slotType;
            m_X = _cnt % (int)slotType;
        }

        // InventoryManager로 넘김
        InventoryManager.Instance.AddSlot(this);
    }
    public void print()
    {
        Debug.Log($"{Y},{X}");
    }
}
