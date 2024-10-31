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
    // �κ��丮 / â�� ����
    private InventorySlot[,] m_inventorySlots;
    private InventorySlot[,] m_chestSlots;

    // �κ��丮 / â�� ������ ���翩�� Ȯ�ο�
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
        // �������� Ÿ�� ���� ��������
        if(ItemManager.Instance.tiles.TryGetValue(_name, out List<ItemTile> tiles))
        {
            // �κ��丮 Ȯ��
            for (int i = 0; i < inventoryState.GetLength(0); i++)
            {
                for(int j = 0; j < inventoryState.GetLength(1); j++)
                {
                    // �������� �������ִ� ��ġ ã��
                    if (!CheckSlot(i,j, ref tiles, SlotType.Inventory))
                        continue;

                    // ������ ����
                    ItemManager.Instance.CreateItem(i, j, _name, SlotType.Inventory, ref m_inventorySlots);

                    // �κ��丮 ��������� ����
                    ChangeState(i, j, ref tiles, SlotType.Inventory);

                    return;
                }
            }

            // â�� Ȯ��
            for(int i = 0; i < chestState.GetLength(0); i++)
            {
                for (int j = 0; j < chestState.GetLength(1); j++)
                {
                    // �������� �������ִ� ��ġ ã��
                    if (!CheckSlot(i, j, ref tiles, SlotType.Chest))
                        continue;

                    // ������ ����
                    ItemManager.Instance.CreateItem(i, j, _name, SlotType.Chest, ref m_chestSlots);

                    // �κ��丮 ��������� ����
                    ChangeState(i, j, ref tiles, SlotType.Chest);

                    return;
                }
            }
        }
    }

    public bool CheckSlot(int _curY, int _curX, ref List<ItemTile> _tiles, SlotType _type)
    {
        // �Ű������� ���� SlotType�� ����Ͽ�
        // �˻��� ������ ���� �� ���� �迭�� ����
        int maxY = _type == SlotType.Inventory ? 5 : 2;
        int maxX = _type == SlotType.Inventory ? 5 : 6;
        bool[,] checkState = _type == SlotType.Inventory ? inventoryState : chestState;

        // ���� ������ �������� tile �����ͷ� �������� �����ɼ��ִ� ��ġ�� �˻�
        for (int slot = 0; slot < _tiles.Count; slot++)
        {
            // �˻��ؾ��� ��ġ
            int y = _curY + _tiles[slot].y;
            int x = _curX + _tiles[slot].x;

            if (y >= maxY || x >= maxX)
            {
                Debug.Log("���� ����! ( ���� �ʰ� )");
                return false;
            }

            // �̹� �������
            if (checkState[y, x])
            {
                Debug.Log("���� ����! ( �̹� ����� )");
                return false;
            }
        }
        // ��� Ÿ�ϰ��� ��밡���ϴٸ� true ��ȯ
        return true;
    }

    private void ChangeState(int _curY, int _curX, ref List<ItemTile> _tiles, SlotType _type)
    {
        // �Ű������� ���� ����Ÿ������ 
        // ���¸� �ٲ� ���� �迭�� ����
        bool[,] changeState = _type == SlotType.Inventory ? inventoryState : chestState;

        // �κ��丮 ��������� ����
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
