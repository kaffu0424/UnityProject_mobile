using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private RectTransform   m_rect;
    private Image           m_image;
    private SlotType        m_slotType;

    // 데이터 확인하기 위해 인스펙터창에 노출
    [SerializeField] private int m_X;           // 위치 X값
    [SerializeField] private int m_Y;           // 위치 Y값
    [SerializeField] private bool m_state;      // 해당 위치에 아이템 존재여부
    [SerializeField] private ItemObject m_item; // 해당 위치에 있는 아이템

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
}
