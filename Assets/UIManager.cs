using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : Singleton_Mono<UIManager>
{
    [SerializeField] private Canvas m_canvas;

    // Mouse Event
    private GraphicRaycaster    m_graphicRay;
    public PointerEventData    m_pointerEventData;
    private EventSystem         m_eventSystem;
    private List<RaycastResult> m_results;

    // Slot Color
    private Color m_defaultColor;
    private Color m_greenColor;
    private Color m_redColor;

    // Get / Set
    public Canvas canvas { get { return m_canvas; } }
    public GraphicRaycaster graphicRay { get { return m_graphicRay; } }
    public EventSystem eventSystem { get { return m_eventSystem; } }
    public List<RaycastResult> results { get { return m_results; } }
    public PointerEventData pointerEventData { get { return m_pointerEventData; } }

    public Color defaultColor => m_defaultColor;
    public Color greenColor => m_greenColor;
    public Color redColor => m_redColor;

    protected override void InitializeManager()
    {
        m_graphicRay    = canvas.GetComponent<GraphicRaycaster>();
        m_eventSystem   = EventSystem.current;
        m_results       = new List<RaycastResult>();

        // 인벤토리 슬롯 색상 초기화
        m_defaultColor  = new Color(255, 255, 255);
        m_greenColor    = new Color(140, 255, 140);
        m_redColor      = new Color(255, 140, 140);
    }

    public void InventoryRayCast()
    {
        m_pointerEventData = new PointerEventData(eventSystem)
        { position = Input.mousePosition };

        results.Clear();
        graphicRay.Raycast(m_pointerEventData, results);
    }
}
