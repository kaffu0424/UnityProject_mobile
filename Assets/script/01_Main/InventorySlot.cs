using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private RectTransform   m_rect;
    private Image           m_image;
    private SlotType        m_slotType;

    // ������ Ȯ���ϱ� ���� �ν�����â�� ����
    [SerializeField] private int m_X;           // ��ġ X��
    [SerializeField] private int m_Y;           // ��ġ Y��
    [SerializeField] private bool m_state;      // �ش� ��ġ�� ������ ���翩��
    [SerializeField] private ItemObject m_item; // �ش� ��ġ�� �ִ� ������

    // get / set
    public RectTransform rect { get { return m_rect; } }
    public Image image { get { return m_image; } }
    public SlotType slotType { get { return m_slotType; } }

    public int X { get { return m_X; } }
    public int Y { get { return m_Y; } }

    public bool state { get { return m_state; } set {  m_state = value; } }
    public ItemObject item { get { return m_item; }  set { m_item = value; } }
    public void InitSlot(int _cnt, SlotType _type)
    {
        gameObject.name = "slot";

        // GetComponent
        m_rect = GetComponent<RectTransform>();
        m_image = GetComponent<Image>();

        // Init
        m_slotType = _type;
        m_state = false;
        item = null;

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
}
