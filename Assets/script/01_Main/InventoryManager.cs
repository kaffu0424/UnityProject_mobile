using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType
{
    Inventory,
    Chest
}

public enum ItemType
{
    A,
    B,
    C,
    D
}

public class InventoryManager : Singleton_Mono<InventoryManager>
{
    // Size
    public int inventorySize { get { return 25; }}
    public int chestSize { get { return 12; }}

    public int inventoryRowSize { get { return inventorySize / 5; } }
    public int chestRowSize { get { return chestSize / 2; } }

    // �κ��丮 / â�� ����
    private InventorySlot[] m_inventorySlots;
    private InventorySlot[] m_chestSlots;

    // �κ��丮 / â�� ������ ���翩�� Ȯ�ο�
    [SerializeField] private bool[] m_inventory;
    [SerializeField] private bool[] m_chest;

    // �ӽ� ������ ������Ʈ
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private RectTransform objectsRect;

    // Get / Set
    public InventorySlot[] inventorySlot { get { return m_inventorySlots; }}
    public InventorySlot[] chestSlot { get { return m_chestSlots; }}

    protected override void InitializeManager()
    {
        m_inventory         = new bool[inventorySize];
        m_chest             = new bool[chestSize];

        m_inventorySlots    = new InventorySlot[inventorySize];
        m_chestSlots        = new InventorySlot[chestSize];
    }

    public void AddSlot(InventorySlot _slot)
    {
        if(_slot.slotType == SlotType.Inventory)
            m_inventorySlots[_slot.index] = _slot;  
        else
            m_chestSlots[_slot.index] = _slot;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            for(int i = 0; i < objects.Count; i++)
            {
                Item item = Instantiate(objects[i], objectsRect).GetComponent<Item>();

                //int index = FindSlot(item.sizeX, item.sizeY);
            }
        }
    }

    public int FindSlot(int _sizeX, int _sizeY)
    {
        int ret = 0;

        for(int i = 0; i < inventorySlot.Length; i++)
        {
            // ������ �Ǵ� ù��° ������ �������������
            // ���� �������� �Ѿ
            if (inventorySlot[i])
                continue;

            // ������ �� ������ ���������
            // ������ �����ŭ Ž�� ����
            int x = inventorySlot[i].X;
            int y = inventorySlot[i].Y;
            int maxX = x + _sizeX;
            int maxY = y + _sizeY;  
            // ������ �����ϱ� BFS�� �ص��ǰ���?
            // BFS Ž��
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            List< KeyValuePair<int, int>> isList = new List<KeyValuePair<int, int>>();

            queue.Enqueue(new KeyValuePair<int, int>(x, y));
            isList.Add(new KeyValuePair<int, int>(x, y));

            while(queue.Count > 0)
            {
                KeyValuePair<int, int> curPos = queue.Dequeue();
                int curX = curPos.Key;
                int curY = curPos.Value;

                // ���� �Ѿ�� �ȵ�!
                if (curX < x || curY < y || curX >= maxX || curY >= maxY)
                    break;


            }
        }


        return ret;
    }
}
