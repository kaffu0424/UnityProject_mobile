using System;
using System.Collections.Generic;
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

    // 인벤토리 / 창고 아이템 존재여부 확인용
    [SerializeField] private bool[,] m_inventoryState;
    [SerializeField] private bool[,] m_chestState;


    // Get / Set
    public int inventorySize { get { return 25; } }
    public int chestSize { get { return 12; } }

    public bool[,]          inventoryState  { get { return m_inventoryState; } }
    public bool[,]          chestState      { get { return m_chestState; } }

    public InventorySlot[,] inventorySlots  { get { return m_inventorySlots; }}
    public InventorySlot[,] chestSlots      { get { return m_chestSlots; }}

    protected override void InitializeManager()
    {
        m_inventoryState    = new bool[5,5];
        m_chestState        = new bool[2,6];

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
        // 아이템의 타일 정보 가져오기
        if(ItemManager.Instance.tiles.TryGetValue(_name, out List<ItemTile> tiles))
        {
            // 인벤토리 확인
            for (int i = 0; i < inventoryState.GetLength(0); i++)
            {
                for(int j = 0; j < inventoryState.GetLength(1); j++)
                {
                    // 아이템을 넣을수있는 위치 찾기
                    if (!CheckSlot(i,j, ref tiles, SlotType.Inventory))
                        continue;

                    // 아이템 생성
                    ItemManager.Instance.CreateItem(i, j, _name, SlotType.Inventory, ref m_inventorySlots);

                    // 인벤토리 사용중으로 변경
                    ChangeState(i, j, ref tiles, SlotType.Inventory);

                    return;
                }
            }

            // 창고 확인
            for(int i = 0; i < chestState.GetLength(0); i++)
            {
                for (int j = 0; j < chestState.GetLength(1); j++)
                {
                    // 아이템을 넣을수있는 위치 찾기
                    if (!CheckSlot(i, j, ref tiles, SlotType.Chest))
                        continue;

                    // 아이템 생성
                    ItemManager.Instance.CreateItem(i, j, _name, SlotType.Chest, ref m_chestSlots);

                    // 인벤토리 사용중으로 변경
                    ChangeState(i, j, ref tiles, SlotType.Chest);

                    return;
                }
            }
        }
    }

    public bool CheckSlot(int _curY, int _curX, ref List<ItemTile> _tiles, SlotType _type)
    {
        // 매개변수로 받은 SlotType을 사용하여
        // 검사할 슬롯의 범위 및 상태 배열을 선택
        int maxY = _type == SlotType.Inventory ? 5 : 2;
        int maxX = _type == SlotType.Inventory ? 5 : 6;
        bool[,] checkState = _type == SlotType.Inventory ? inventoryState : chestState;

        // 현재 생성된 아이템의 tile 데이터로 아이템이 생성될수있는 위치를 검사
        for (int slot = 0; slot < _tiles.Count; slot++)
        {
            // 검사해야할 위치
            int y = _curY + _tiles[slot].y;
            int x = _curX + _tiles[slot].x;

            if (y >= maxY || x >= maxX)
            {
                Debug.Log("여긴 못씀! ( 범위 초과 )");
                return false;
            }

            // 이미 사용중임
            if (checkState[y, x])
            {
                Debug.Log("여긴 못씀! ( 이미 사용중 )");
                return false;
            }
        }
        // 모든 타일값이 사용가능하다면 true 반환
        return true;
    }

    private void ChangeState(int _curY, int _curX, ref List<ItemTile> _tiles, SlotType _type)
    {
        // 매개변수로 받은 슬롯타입으로 
        // 상태를 바꿀 슬롯 배열을 선택
        bool[,] changeState = _type == SlotType.Inventory ? inventoryState : chestState;

        // 인벤토리 사용중으로 변경
        for (int slot = 0; slot < _tiles.Count; slot++)
        {
            int y = _curY + _tiles[slot].y;
            int x = _curX + _tiles[slot].x;

            changeState[y, x] = true;
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
            for(int i = 0; i < inventoryState.GetLength(0); i++)
            {
                string a = "";
                for(int j = 0; j < inventoryState.GetLength(0); j++)
                {
                    a += inventoryState[i, j] ? " O " : " X ";
                }
                Debug.Log(a);
            }
        }
    }
}
