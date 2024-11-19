using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType
{
    Inventory,
    Chest
}

public class InventoryManager : Singleton_Mono<InventoryManager>
{
    #region 인벤토리 로직용 변수
    List<ItemTile> t_tiles; 
    ItemPos t_pos;
    int t_y; 
    int t_x;
    int t_maxY; 
    int t_maxX;
    #endregion

    public int inventorySize => 25;
    public int chestSize => 10;

    // 인벤토리 / 창고 슬롯 및 아이템데이터
    private InventorySlot[,] m_inventorySlots;
    private InventorySlot[,] m_chestSlots;

    public ref InventorySlot[,] inventorySlots  { get { return ref m_inventorySlots; }}
    public ref InventorySlot[,] chestSlots      { get { return ref m_chestSlots; }}

    protected override void InitializeManager()
    {
        m_inventorySlots    = new InventorySlot[5, 5];
        m_chestSlots        = new InventorySlot[2, 5];
    }

    public void GetItem(ItemName _name)
    {
        t_tiles = ItemManager.Instance.GetItemTiles(_name);
        // 아이템 획득
        // 1. 비어있는 기준점 탐색
        // 2. 비어있는 기준점을 중심으로 생성될 아이템의 타일정보로 탐색
        // 3. 전부 비어있다면 생성

        // 인벤토리 슬롯 확인
        if (CheckAllSlot(ref inventorySlots, ref t_tiles, out t_pos))
        {

        }
        // 창고 슬롯 확인
        else if (CheckAllSlot(ref chestSlots, ref t_tiles, out t_pos))
        {

        }
    }

    public bool CheckAllSlot(ref InventorySlot[,] _slots, ref List<ItemTile> _tiles, out ItemPos _pos)
    {
        _pos = new ItemPos(-1, -1);
        t_maxY = _slots.GetLength(0);
        t_maxX = _slots.GetLength(1);

        for (t_y = 0; t_y < t_maxY; t_y++)
        {
            for (t_x = 0; t_x < t_maxX; t_x++)
            {
                // 이미 아이템이 있는 칸 
                if (_slots[t_y, t_x].item != null)
                    continue;

                // 생성된 아이템의 타일데이터 확인
                if (!CheckTile(ref _slots, ref _tiles))
                    continue;

                // 기준점에 아이템이없고, 다른 타일도 배치가 가능한 위치일때
                // 흠..
            }
        }

        return false;
    }
    public bool CheckTile(ref InventorySlot[,] _slots, ref List<ItemTile> _tiles)
    {
        for (int i = 0; i < _tiles.Count; i++)
        {
            int nextY = t_y + _tiles[i].y;
            int nextX = t_x + _tiles[i].x;

            // 범위 넘어감
            if (nextX < 0 || nextY < 0)
                return false;

            // 범위 넘어감
            if (nextX >= t_maxX || nextY >= t_maxY)
                return false;

            // 아이템 있음
            if (_slots[nextY, nextX].item != null)
                return false;
        }

        return true;
    }
}