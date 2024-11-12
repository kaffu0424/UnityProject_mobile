using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour, IPointerClickHandler , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform m_rect;

    // ������ ������ ( ���� 0,0 )
    [SerializeField] private List<ItemTile> m_tiles;

    // �κ��丮 �迭�� ��ġ
    private ItemPos m_pos;
    // ���� ��ġ�� ����Ÿ��
    private SlotType m_currentSlotType;
    // �������� �̸�
    private ItemName m_itemName;

    // get / set
    public List<ItemTile> tiles { get { return m_tiles; } }
    public ItemPos pos { get { return m_pos; } }
    public ItemName itemName { get { return m_itemName; } }

    public void InitItem(int _posY, int _posX, ItemName _name, SlotType _type)
    {
        m_pos               = new ItemPos(_posX, _posY);
        m_currentSlotType   = _type;
        m_itemName = _name;

        // Componoents
        m_rect              = GetComponent<RectTransform>();

        // ������ ũ�� ����
        float cellSize      = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);

        int maxX = 0, maxY = 0;
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].x >= maxX)
                maxX = tiles[i].x;
            if (tiles[i].y >= maxY)
                maxY = tiles[i].y;
        }

        m_rect.sizeDelta = new Vector2(
            (cellSize + cellSize * maxX), cellSize + (cellSize * maxY));


    }

    public void MoveToPosition(Vector3 _rectPosition)
    {
        m_rect.position = _rectPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ���۽�
        // ������Ʈ ������ �� �Ʒ��� ����
        // �巡������ ������Ʈ�� ���� ���� ���̵��� �ϱ�����
        transform.SetAsLastSibling();

        // �巡�� ������ �������� Ÿ������ InventoryManager�� �ѱ��
        if (!ItemManager.Instance.tiles.TryGetValue(itemName, out InventoryManager.Instance.m_tiles))
            return;


        InventoryManager.Instance.ChangeState(ref m_pos, ref GetSlots(m_currentSlotType), false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �巡���� ������ �̹��� �������
        float cellSize = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);
        Vector2 offset = new Vector2(-cellSize / 2, cellSize / 2);
        gameObject.transform.position = eventData.position + offset;


        // UI RayCast
        UIManager.Instance.InventoryRayCast();

        // RayCast �����
        foreach (RaycastResult result in UIManager.Instance.results)
        {
            if(result.gameObject.name == "slot")
            {
                // slot : ���� ���콺�� �ö��ִ� ��ġ�� ����
                InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();

                if(InventoryManager.Instance.CheckCurrentSlot(pos, ref GetSlots(slot.slotType), slot.slotType))
                {
                    // �̵� ������ ��ġ�϶� ����
                }
                else
                {
                    // �̵� �Ұ����� ��ġ�϶� ����
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �ű���ִ� ��ġ �϶�
        /*
         * 1. ������ġ ���� ( �κ��丮 �迭 )
         * 2. ���Ӱ� �ű� ��ġ�� ������ �̹��� �̵�
         * 3. m_pos �� ���� ( ���ο� ��ġ )
         * 4. ���Ұ� �ű� ��ġ ä��� ( �κ��丮 �迭 )
         */

        // �ű������ ��ġ �϶�
        /*
         * 1. �̹����� ���� ��ġ�� ����������
         * 2. ����� ���� �ʱ�ȭ�ϱ�
         */

        Debug.Log("END Drag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click " + gameObject.name);
    }


    // ���� �������� ��ġ�� ������ �迭�� ��ȯ
    // Get ���� �ҷ��ٰ� �Ű������� �޾Ƽ� �Ҽ��ֵ��� �ҷ��� �Լ��� ����
    public ref InventorySlot[,] GetSlots(SlotType _type)
    {
            if (_type == SlotType.Inventory)
                return ref InventoryManager.Instance.inventorySlots;
            else
                return ref InventoryManager.Instance.chestSlots;
    }
}
