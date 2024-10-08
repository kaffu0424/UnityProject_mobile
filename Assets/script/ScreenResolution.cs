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
        SetResolution();    // 해상도 설정
        InitData();         // 해상도 데이터 저장
    }
    private void SetResolution()
    {
        // 화면 해상도 설정
        canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        // 게임 화면 UI
        // UI.width  = Screen.width
        // UI.Heigth = 1920 의 70%
        uiRect.sizeDelta = new Vector2(Screen.width, (Screen.height * gameViewRatio_UI));

        // Camera rect 설정
        // camera.width = Screen.width
        // camera.height = 1920 의 30%
        cameraRect.sizeDelta = new Vector2(Screen.width, (Screen.height * gameViewRatio_Camera));

        // Render Texture 해상도 설정
        cameraTexture.width = Screen.width;
        cameraTexture.height = (int)cameraRect.sizeDelta.y;

    }

    private void InitData()
    {
        // Resolution Data 초기화
        // 추후 해상도 대응에 활용할거같으니 미리 해두자!

        // 화면 길이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // 화면 높이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);

        // UI 영역 길이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.UIRECT_WIDTH, Screen.width);
        // UI 영역 높이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.UIRECT_HEIGHT, (Screen.height * gameViewRatio_UI));

        // 게임 영역 길이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.CAMERARECT_WIDTH, Screen.width);
        // 게임 영역 높이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.CAMERARECT_HEIGHT, (int)cameraRect.sizeDelta.y);
    }
}
