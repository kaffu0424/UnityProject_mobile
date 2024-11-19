using System.Collections.Generic;
using UnityEngine;

public enum ItemName
{
    G67,
    Sword,
}

[System.Serializable]
public struct ItemTile
{
    public int m_x;
    public int m_y;
    public int x { get { return m_x; } }
    public int y { get { return m_y; } }
}

[System.Serializable]
public struct ItemPos
{
    public int m_x;
    public int m_y;
    public int x { get { return m_x; } set { m_x = value; } }
    public int y { get { return m_y; } set { m_y = value; } }

    public ItemPos(int _x, int _y)
    {
        m_x = _x;
        m_y = _y;
    }
}

public class ItemManager : Singleton_Mono<ItemManager>
{
    [SerializeField] private List<GameObject>                       m_itemPrefabs;  // 아이템 프리팹
    [SerializeField] private RectTransform                          m_itemsRect;    // 생성된 아이템 보관할 Transform
    [SerializeField] private Dictionary<ItemName, List<ItemTile>>       m_tiles;        // 아이템 타일정보

    // Get / Set
    public List<GameObject>                     itemPrefabs { get { return m_itemPrefabs; } }
    public RectTransform                        itemsRect   { get { return m_itemsRect; } }

    protected override void InitializeManager()
    {
        m_tiles = new Dictionary<ItemName, List<ItemTile>>();

        for(int i = 0; i < m_itemPrefabs.Count; i++)
        {
            m_tiles.Add((ItemName)i, m_itemPrefabs[i].GetComponent<ItemObject>().tiles);
        }   
    }
    
    public List<ItemTile> GetItemTiles(ItemName _name)
    {
        if(m_tiles.TryGetValue(_name, out List<ItemTile> tiles))
        {
            return tiles;
        }

        return null;
    }
}
