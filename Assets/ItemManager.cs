using System.Collections.Generic;
using UnityEngine;

public enum ItemName
{
    G67,
    Sword,
    M4
}

[System.Serializable]
public struct ItemTile
{
    public int m_x;
    public int m_y;
    public int x { get { return m_x; } }
    public int y { get { return m_y; } }
}

public class ItemManager : Singleton_Mono<ItemManager>
{
    [SerializeField] private List<GameObject>                       m_itemPrefabs;
    [SerializeField] private RectTransform                          m_itemsRect;
    [SerializeField] private Dictionary<ItemName, List<ItemTile>>   m_tiles;
    // Get / Set
    public List<GameObject>                     itemPrefabs { get { return m_itemPrefabs; } }
    public RectTransform                        itemsRect   { get { return m_itemsRect; } }
    public Dictionary<ItemName, List<ItemTile>> tiles       { get { return m_tiles; } }
    protected override void InitializeManager()
    {
        m_tiles = new Dictionary<ItemName, List<ItemTile>>();
        for(int i = 0; i < m_itemPrefabs.Count; i++)
        {
            m_tiles.Add(
                (ItemName)i, m_itemPrefabs[i].GetComponent<ItemObject>().tiles);
        }   
    }

    public void CreateItem(ItemName _name, int _posY, int _posX, ref InventorySlot[,] _slots)
    {
        ItemObject newitem = Instantiate(itemPrefabs[(int)_name], itemsRect).GetComponent<ItemObject>();
        newitem.InitItem();
        newitem.MoveToPosition(_slots[_posY, _posX].rect.position);
    }
}