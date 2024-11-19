using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private List<ItemTile> m_tiles;
    private RectTransform m_rect;

    // Get / Set
    public List<ItemTile> tiles { get { return m_tiles; } }

    public void InitItem()
    {
        // 아이템 이미지 크기 조절
        float cellSize      = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);

        // 아이템의 크기
        int maxX = 0, maxY = 0;
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].x >= maxX)
                maxX = tiles[i].x;
            if (tiles[i].y >= maxY)
                maxY = tiles[i].y;
        }

        // 사이즈 조정
        float sizeX = cellSize + (cellSize * maxX);
        float sizeY = cellSize + (cellSize * maxY);
        m_rect.sizeDelta = new Vector2(sizeX, sizeY);
    }

    public void MoveToPosition(Vector3 _rectPosition)
    {
        m_rect.position = _rectPosition;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

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
}