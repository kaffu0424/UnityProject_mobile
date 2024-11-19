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
    #region �κ��丮 ������ ����
    List<ItemTile> t_tiles; 
    ItemPos t_pos;
    int t_y; 
    int t_x;
    int t_maxY; 
    int t_maxX;
    #endregion

    public int inventorySize => 25;
    public int chestSize => 10;

    // �κ��丮 / â�� ���� �� �����۵�����
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
        // ������ ȹ��
        // 1. ����ִ� ������ Ž��
        // 2. ����ִ� �������� �߽����� ������ �������� Ÿ�������� Ž��
        // 3. ���� ����ִٸ� ����

        // �κ��丮 ���� Ȯ��
        if (CheckAllSlot(ref inventorySlots, ref t_tiles, out t_pos))
        {

        }
        // â�� ���� Ȯ��
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
                // �̹� �������� �ִ� ĭ 
                if (_slots[t_y, t_x].item != null)
                    continue;

                // ������ �������� Ÿ�ϵ����� Ȯ��
                if (!CheckTile(ref _slots, ref _tiles))
                    continue;

                // �������� �������̾���, �ٸ� Ÿ�ϵ� ��ġ�� ������ ��ġ�϶�
                // ��..
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

            // ���� �Ѿ
            if (nextX < 0 || nextY < 0)
                return false;

            // ���� �Ѿ
            if (nextX >= t_maxX || nextY >= t_maxY)
                return false;

            // ������ ����
            if (_slots[nextY, nextX].item != null)
                return false;
        }

        return true;
    }
}