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

    // 인벤토리 / 창고 슬롯
    private InventorySlot[] m_inventorySlots;
    private InventorySlot[] m_chestSlots;

    // 인벤토리 / 창고 아이템 존재여부 확인용
    [SerializeField] private bool[] m_inventory;
    [SerializeField] private bool[] m_chest;

    // 임시 아이템 오브젝트
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
            // 기준이 되는 첫번째 슬롯이 비어있지않을때
            // 다음 기준으로 넘어감
            if (inventorySlot[i])
                continue;

            // 기준이 될 슬롯이 비어있으면
            // 아이템 사이즈만큼 탐색 시작
            int x = inventorySlot[i].X;
            int y = inventorySlot[i].Y;
            int maxX = x + _sizeX;
            int maxY = y + _sizeY;  
            // 사이즈 작으니까 BFS로 해도되겠지?
            // BFS 탐색
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            List< KeyValuePair<int, int>> isList = new List<KeyValuePair<int, int>>();

            queue.Enqueue(new KeyValuePair<int, int>(x, y));
            isList.Add(new KeyValuePair<int, int>(x, y));

            while(queue.Count > 0)
            {
                KeyValuePair<int, int> curPos = queue.Dequeue();
                int curX = curPos.Key;
                int curY = curPos.Value;

                // 범위 넘어서면 안됨!
                if (curX < x || curY < y || curX >= maxX || curY >= maxY)
                    break;


            }
        }


        return ret;
    }
}
