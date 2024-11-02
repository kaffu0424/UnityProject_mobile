using System;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public enum SlotType
{
    Inventory = 5,
    Chest = 6
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
    // 인벤토리 / 창고 슬롯
    private InventorySlot[,] m_inventorySlots;
    private InventorySlot[,] m_chestSlots;

    // 인벤토리 / 창고 아이템  데이터
    // InventorySlot[,] 배열과 연동하여 아이템 존재여부 확인
    // inventorySlots에 있는 아이템 확인
    private ItemObject[,] m_inventory;
    private ItemObject[,] m_chest;

    // 아이템 획득에 필요한 변수 미리 선언
    private List<ItemTile> m_tiles;
    // Get / Set
    public int inventorySize { get { return 25; } }
    public int chestSize { get { return 12; } }

    public ItemObject[,]          inventory  { get { return m_inventory; } }
    public ItemObject[,]          chest      { get { return m_chest; } }

    public InventorySlot[,] inventorySlots  { get { return m_inventorySlots; }}
    public InventorySlot[,] chestSlots      { get { return m_chestSlots; }}

    public List<ItemTile> tiles { get { return m_tiles; }}

    protected override void InitializeManager()
    {
        m_inventory = new ItemObject[5,5];
        m_chest     = new ItemObject[2,6];

        m_inventorySlots    = new InventorySlot[5,5];
        m_chestSlots        = new InventorySlot[2,6];
    }

    public void AddSlot(InventorySlot _slot)
    {
        int y = _slot.Y;
        int x = _slot.X;

        if(_slot.slotType == SlotType.Inventory)
            m_inventorySlots[y, x] = _slot;
        else
            m_chestSlots[y, x] = _slot;
    }


    public void GetItem(ItemName _name)
    {
        ItemPos curPos;
        // 아이템의 타일 정보 가져오기
        if(ItemManager.Instance.tiles.TryGetValue(_name, out m_tiles))
        {
            // 인벤토리 확인 및 생성
            if (CheckSlots(ref m_inventorySlots, SlotType.Inventory, out curPos))
            {
                if(curPos.x != -1)
                {
                    // 아이템 생성
                    ItemManager.Instance.CreateItem(
                        curPos, _name, SlotType.Inventory, ref m_inventorySlots);

                    // 인벤토리 사용중으로 변경
                    ChangeState(ref curPos, ref m_inventorySlots);

                    return;
                }
            }

            // 창고 확인 및 생성
            else if(CheckSlots(ref m_chestSlots, SlotType.Chest, out curPos))
            {
                // 아이템 생성
                if(curPos.x != -1)
                {
                    // 아이템 생성
                    ItemManager.Instance.CreateItem(
                        curPos, _name, SlotType.Chest, ref m_chestSlots);

                    // 인벤토리 사용중으로 변경
                    ChangeState(ref curPos, ref m_chestSlots);
                    return;
                }

            }
        }
    }

    private bool CheckSlots(ref InventorySlot[,] _inven, SlotType _type, out ItemPos _pos)
    {
        _pos = new ItemPos(-1, -1);
        // 사용가능한 슬롯이 없을때 -1를 반환하여 아이템이 생성되지않도록 함
        for (int y = 0; y < _inven.GetLength(0); y++)
        {
            for (int x = 0; x < _inven.GetLength(1); x++)
            {
                if (!CheckCurrentSlot(new ItemPos(x,y), ref _inven, _type))
                    continue;

                _pos.x = x;
                _pos.y = y;

                return true;
            }
        }
        return false;
    }

    public bool CheckCurrentSlot(ItemPos _pos, ref InventorySlot[,] _inven, SlotType _type)
    {
        ItemPos maxPos;
        // 슬롯의 타입에 맞는 슬롯의 범위
        if (_type == SlotType.Inventory)
            maxPos = new ItemPos(5, 5);
        else
            maxPos = new ItemPos(6, 2);

        // 현재 생성된 아이템의 tile 데이터로 아이템이 생성될수있는 위치를 검사
        for (int slot = 0; slot < tiles.Count; slot++)
        {
            // 검사해야할 위치
            int y = _pos.y + tiles[slot].y;
            int x = _pos.x + tiles[slot].x;

            if (y >= maxPos.y || x >= maxPos.x)
            {
                Debug.Log("여긴 못씀! ( 범위 초과 )");
                return false;
            }

            // 이미 사용중임
            if (_inven[y, x].state)
            {
                Debug.Log("여긴 못씀! ( 이미 사용중 )");
                return false;
            }
        }

        // 모든 타일값이 사용가능하다면 true 반환
        return true;
    }

    private void ChangeState(ref ItemPos curPos, ref InventorySlot[,] _inven)
    {
        // 인벤토리 사용중으로 변경
        for (int slot = 0; slot < tiles.Count; slot++)
        {
            int y = curPos.y + tiles[slot].y;
            int x = curPos.x + tiles[slot].x;

            _inven[y, x].state = true;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetItem(ItemName.G67);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetItem(ItemName.Sword);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetItem(ItemName.M4);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            for(int i = 0; i < inventory.GetLength(0); i++)
            {
                string a = "";
                for(int j = 0; j < inventory.GetLength(0); j++)
                {
                    a += inventorySlots[i, j].state ? " O " : " X ";
                }
                Debug.Log(a);
            }
        }
    }
}
