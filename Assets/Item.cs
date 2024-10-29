using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    private RectTransform m_rect;

    [SerializeField] private int m_sizeX;
    [SerializeField] private int m_sizeY;

    // get / set
    public int sizeX { get { return m_sizeX; } }
    public int sizeY { get { return m_sizeY; } }

    private void Start()
    {
        // RectTrasnform
        m_rect = GetComponent<RectTransform>();

        // 아이템 크기 조절
        float cellSize = ResolutionData.Instance.GetData(RESOLUTION_DATA.SLOTSIZE);
        m_rect.sizeDelta = new Vector2(cellSize * m_sizeX, cellSize * m_sizeY);

    }

    public void MoveToPosition(Vector3 _rectPosition)
    {
        m_rect.position = _rectPosition;
    }
}
