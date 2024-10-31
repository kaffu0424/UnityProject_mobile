using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour, IPointerClickHandler , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform m_rect;

    // 아이템 사이즈 ( 기준 0,0 )
    [SerializeField] private List<ItemTile> m_tiles;

    // 인벤토리 배열상 위치
    private Vector2 m_pos;
    // 현재 위치한 슬롯타입
    private SlotType m_currentSlotType;
    // 아이템의 이름
    private ItemName m_name;

    // get / set
    public List<ItemTile> tiles { get { return m_tiles; } }
    public Vector2 pos { get { return m_pos; } }
    public ItemName name { get { return m_name; } }
    public void InitItem(int _posY, int _posX, ItemName _name, SlotType _type)
    {
        m_pos               = new Vector2(_posX, _posY);
        m_currentSlotType   = _type;
        m_name              = _name;

        // Componoents
        m_rect              = GetComponent<RectTransform>();

        // 아이템 크기 조절
        float cellSize      = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);

        int maxX = 0, maxY = 0;
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].x >= maxX)
                maxX = tiles[i].x;
            if (tiles[i].y >= maxY)
                maxY = tiles[i].y;
        }

        m_rect.sizeDelta = new Vector2(
            (cellSize + cellSize * maxX), cellSize + (cellSize * maxY));


    }

    public void MoveToPosition(Vector3 _rectPosition)
    {
        m_rect.position = _rectPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작시
        // 오브젝트 순서를 맨 아래로 변경
        // 드래그중인 오브젝트을 가장 위에 보이도록 하기위함
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그중 아이템 이미지 따라오기
        float cellSize = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);
        Vector2 offset = new Vector2(-cellSize / 2, cellSize / 2);
        gameObject.transform.position = eventData.position + offset;


        // UI RayCast
        UIManager.Instance.InventoryRayCast();

        // RayCast 결과물
        foreach (RaycastResult result in UIManager.Instance.results)
        {
            if(result.gameObject.name == "slot")
            {
                InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();

                if(ItemManager.Instance.tiles.TryGetValue(m_name, out List<ItemTile> tiles))
                {
                    if (InventoryManager.Instance.CheckSlot(slot.Y, slot.X, ref tiles, m_currentSlotType))
                    {
                        // 현재위치 가능
                        Image[] images = GetComponentsInChildren<Image>();
                        foreach(Image i in images)
                        {
                            i.color = new Color(0, 255, 0, 50);
                        }
                    }
                    else
                    {
                        // 불가능
                        Image[] images = GetComponentsInChildren<Image>();
                        foreach (Image i in images)
                        {
                            i.color = new Color(255, 0, 0, 50);
                        }
                    }

                    // 현재 발견된 이슈
                    // 1. 드래그중인 아이템이 원래있던 위치도 감지를해서 빨간색으로 떠버림..
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 옮길수있는 위치 일때
        /*
         * 1. 기존위치 비우기 ( 인벤토리 배열 )
         * 2. 새롭게 옮길 위치로 아이템 이미지 이동
         * 3. m_pos 값 수정 ( 새로운 위치 )
         * 4. 새롬게 옮긴 위치 채우기 ( 인벤토리 배열 )
         */

        // 옮길수없는 위치 일때
        /*
         * 1. 이미지를 원래 위치로 돌려보내기
         * 2. 사용한 변수 초기화하기
         */

        Debug.Log("END Drag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click " + gameObject.name);
    }
}
