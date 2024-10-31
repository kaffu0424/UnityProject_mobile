using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private RectTransform m_rect;
    private SlotType m_slotType;

    // ������ Ȯ���ϱ� ���� �ν�����â�� ����
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

        // �迭 ù��° 0,0 �϶� ����ó��
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

        // InventoryManager�� �ѱ�
        InventoryManager.Instance.AddSlot(this);
    }
    public void print()
    {
        Debug.Log($"{Y},{X}");
    }
}
