using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenResolution : MonoBehaviour
{
    private const float gameViewRatio_UI = 0.7f;
    private const float gameViewRatio_Camera = 0.3f;

    CanvasScaler canvasScaler;

    public RenderTexture cameraTexture;

    public RectTransform cameraRect;
    public RectTransform uiRect;
    void Awake()
    {
        SetResolution();    // �ػ� ����
        InitData();         // �ػ� ������ ����
        ChangeAnchors();    // UI Anchors ����
    }
    private void SetResolution()
    {
        // ȭ�� �ػ� ����
        canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        // ���� ȭ�� UI
        // UI.width  = Screen.width
        // UI.Heigth = 1920 �� 70%
        uiRect.sizeDelta = new Vector2(Screen.width, (Screen.height * gameViewRatio_UI));

        // Camera rect ����
        // camera.width = Screen.width
        // camera.height = 1920 �� 30%
        cameraRect.sizeDelta = new Vector2(Screen.width, (Screen.height * gameViewRatio_Camera));


        // Render Texture �ػ� ����
        cameraTexture.width = Screen.width;
        cameraTexture.height = (int)cameraRect.sizeDelta.y;
    }

    private void ChangeAnchors()
    {
        // Anchors�� ����
        // UI ����
        uiRect.anchorMin = new Vector2(0f, 0f);                     // min x : 0  /  y : 0
        uiRect.anchorMax = new Vector2(1f, gameViewRatio_UI);       // max x : 1  /  y : 0.7
        uiRect.offsetMin = new Vector2(0, 0);                       // left , bottom
        uiRect.offsetMax = new Vector2(0, 0);                       // right , top

        // Camera ����
        cameraRect.anchorMin = new Vector2(0f, gameViewRatio_UI);   // min x : 0  /  y : 0.7
        cameraRect.anchorMax = new Vector2(1f, 1f);                 // max x : 1  /  y : 1
        cameraRect.offsetMin = new Vector2(0, 0);                   // left , bottom
        cameraRect.offsetMax = new Vector2(0, 0);                   // right , top
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
        ResolutionData.Instance.SetData(RESOLUTION_DATA.UIRECT_HEIGHT, (Screen.height * gameViewRatio_UI));

        // ���� ���� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.CAMERARECT_WIDTH, Screen.width);
        // ���� ���� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.CAMERARECT_HEIGHT, (Screen.height * gameViewRatio_Camera));
    }
}