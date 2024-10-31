using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour, IPointerClickHandler , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform m_rect;

    // 아이템 사이즈 ( 기준 0,0 )
    [SerializeField] private List<ItemTile> m_tiles;

    // get / set
    public List<ItemTile> tiles { get { return m_tiles; } }

    public void InitItem()
    {
        // Componoents
        m_rect          = GetComponent<RectTransform>();

        // 아이템 크기 조절
        float cellSize = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);

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


        // Check for UI elements under the cursor
        UIManager.Instance.m_pointerEventData = new PointerEventData(UIManager.Instance.eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        UIManager.Instance.graphicRay.Raycast(UIManager.Instance.m_pointerEventData, results);

        // Find the first slot UI element in the results
        foreach (RaycastResult result in results)
        {
            if(result.gameObject.name == "slot")
            {
                InventorySlot a = result.gameObject.GetComponent<InventorySlot>();
                Debug.Log($"{a.Y},{a.X} / {a.slotType.ToString()}");
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("END Drag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click " + gameObject.name);
    }
}
