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
        // ������ �̹��� ũ�� ����
        float cellSize      = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);

        // �������� ũ��
        int maxX = 0, maxY = 0;
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].x >= maxX)
                maxX = tiles[i].x;
            if (tiles[i].y >= maxY)
                maxY = tiles[i].y;
        }

        // ������ ����
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
        // �ű���ִ� ��ġ �϶�
        /*
         * 1. ������ġ ���� ( �κ��丮 �迭 )
         * 2. ���Ӱ� �ű� ��ġ�� ������ �̹��� �̵�
         * 3. m_pos �� ���� ( ���ο� ��ġ )
         * 4. ���Ұ� �ű� ��ġ ä��� ( �κ��丮 �迭 )
         */

        // �ű������ ��ġ �϶�
        /*
         * 1. �̹����� ���� ��ġ�� ����������
         * 2. ����� ���� �ʱ�ȭ�ϱ�
         */

        Debug.Log("END Drag");
    }
}