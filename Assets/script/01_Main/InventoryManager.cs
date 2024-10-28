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

public class Item
{
    public ItemType m_type;


}

public class InventoryManager : Singleton_Mono<InventoryManager>
{
    // Size
    public int inventorySize { get { return 25; }}
    public int chestSize { get { return 12; }}

    public int inventoryColumeSize { get { return inventorySize / 5; } }
    public int chestColumeSize { get { return chestSize / 2; } }

    // 인벤토리 / 창고 데이터
    private Item[] m_inventory;    // 25 slot
    private Item[] m_chest;        // 12 slot

    // Get / Set
    public Item[] inventory { get { return m_inventory; }}
    public Item[] chest { get { return m_chest; }}

    protected override void InitializeManager()
    {
        m_inventory = new Item[inventorySize];
        m_chest     = new Item[chestSize];
    }
}
