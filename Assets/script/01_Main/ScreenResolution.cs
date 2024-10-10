using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenResolution : MonoBehaviour
{
    private const float m_gameViewRatio_UI = 0.7f;
    private const float m_gameViewRatio_Camera = 0.3f;

    private CanvasScaler m_canvasScaler;

    public RenderTexture m_cameraTexture;

    public RectTransform m_cameraRect;
    public RectTransform m_uiRect;
    void Awake()
    {
        SetResolution();    // �ػ� ����
        InitData();         // �ػ� ������ ����
        ChangeAnchors();    // UI Anchors ����
    }
    private void SetResolution()
    {
        // ȭ�� �ػ� ����
        m_canvasScaler = GetComponent<CanvasScaler>();
        m_canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        // ���� ȭ�� UI
        // UI.width  = Screen.width
        // UI.Heigth = 1920 �� 70%
        m_uiRect.sizeDelta = new Vector2(Screen.width, (Screen.height * m_gameViewRatio_UI));

        // Camera rect ����
        // camera.width = Screen.width
        // camera.height = 1920 �� 30%
        m_cameraRect.sizeDelta = new Vector2(Screen.width, (Screen.height * m_gameViewRatio_Camera));


        // Render Texture �ػ� ����
        m_cameraTexture.width = Screen.width;
        m_cameraTexture.height = (int)m_cameraRect.sizeDelta.y;
    }

    private void ChangeAnchors()
    {
        // Anchors�� ����
        // UI ����
        m_uiRect.anchorMin = new Vector2(0f, 0f);                     // min x : 0  /  y : 0
        m_uiRect.anchorMax = new Vector2(1f, m_gameViewRatio_UI);       // max x : 1  /  y : 0.7
        m_uiRect.offsetMin = new Vector2(0, 0);                       // left , bottom
        m_uiRect.offsetMax = new Vector2(0, 0);                       // right , top

        // Camera ����
        m_cameraRect.anchorMin = new Vector2(0f, m_gameViewRatio_UI);   // min x : 0  /  y : 0.7
        m_cameraRect.anchorMax = new Vector2(1f, 1f);                 // max x : 1  /  y : 1
        m_cameraRect.offsetMin = new Vector2(0, 0);                   // left , bottom
        m_cameraRect.offsetMax = new Vector2(0, 0);                   // right , top
    }

    private void InitData()
    {
        // Resolution Data �ʱ�ȭ
        // ���� �ػ� ������ Ȱ���ҰŰ����� �̸� �ص���!

        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);

        // UI ���� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.UIRECT_WIDTH, Screen.width);
        // UI ���� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.UIRECT_HEIGHT, (Screen.height * m_gameViewRatio_UI));

        // ���� ���� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.CAMERARECT_WIDTH, Screen.width);
        // ���� ���� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.CAMERARECT_HEIGHT, (Screen.height * m_gameViewRatio_Camera));
    }
}
