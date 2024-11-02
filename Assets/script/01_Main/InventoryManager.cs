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
    // �κ��丮 / â�� ����
    private InventorySlot[,] m_inventorySlots;
    private InventorySlot[,] m_chestSlots;

    // �κ��丮 / â�� ������  ������
    // InventorySlot[,] �迭�� �����Ͽ� ������ ���翩�� Ȯ��
    // inventorySlots�� �ִ� ������ Ȯ��
    private ItemObject[,] m_inventory;
    private ItemObject[,] m_chest;

    // ������ ȹ�濡 �ʿ��� ���� �̸� ����
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
        // �������� Ÿ�� ���� ��������
        if(ItemManager.Instance.tiles.TryGetValue(_name, out m_tiles))
        {
            // �κ��丮 Ȯ�� �� ����
            if (CheckSlots(ref m_inventorySlots, SlotType.Inventory, out curPos))
            {
                if(curPos.x != -1)
                {
                    // ������ ����
                    ItemManager.Instance.CreateItem(
                        curPos, _name, SlotType.Inventory, ref m_inventorySlots);

                    // �κ��丮 ��������� ����
                    ChangeState(ref curPos, ref m_inventorySlots);

                    return;
                }
            }

            // â�� Ȯ�� �� ����
            else if(CheckSlots(ref m_chestSlots, SlotType.Chest, out curPos))
            {
                // ������ ����
                if(curPos.x != -1)
                {
                    // ������ ����
                    ItemManager.Instance.CreateItem(
                        curPos, _name, SlotType.Chest, ref m_chestSlots);

                    // �κ��丮 ��������� ����
                    ChangeState(ref curPos, ref m_chestSlots);
                    return;
                }

            }
        }
    }

    private bool CheckSlots(ref InventorySlot[,] _inven, SlotType _type, out ItemPos _pos)
    {
        _pos = new ItemPos(-1, -1);
        // ��밡���� ������ ������ -1�� ��ȯ�Ͽ� �������� ���������ʵ��� ��
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
        // ������ Ÿ�Կ� �´� ������ ����
        if (_type == SlotType.Inventory)
            maxPos = new ItemPos(5, 5);
        else
            maxPos = new ItemPos(6, 2);

        // ���� ������ �������� tile �����ͷ� �������� �����ɼ��ִ� ��ġ�� �˻�
        for (int slot = 0; slot < tiles.Count; slot++)
        {
            // �˻��ؾ��� ��ġ
            int y = _pos.y + tiles[slot].y;
            int x = _pos.x + tiles[slot].x;

            if (y >= maxPos.y || x >= maxPos.x)
            {
                Debug.Log("���� ����! ( ���� �ʰ� )");
                return false;
            }

            // �̹� �������
            if (_inven[y, x].state)
            {
                Debug.Log("���� ����! ( �̹� ����� )");
                return false;
            }
        }

        // ��� Ÿ�ϰ��� ��밡���ϴٸ� true ��ȯ
        return true;
    }

    private void ChangeState(ref ItemPos curPos, ref InventorySlot[,] _inven)
    {
        // �κ��丮 ��������� ����
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
