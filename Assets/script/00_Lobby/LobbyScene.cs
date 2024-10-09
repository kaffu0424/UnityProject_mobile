using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    private CanvasScaler canvasScaler;
    private void Awake()
    {
        // PlayerPrefs.DeleteKey("PlayerData");

        //������ �ҷ�����
        if (!PlayerData.Instance.LoadData())
        {
            // �����ϸ� ���� ����
            Application.Quit();
        }

        // �κ� �� �ػ� ����
        LobbySetResolution();
    }

    public void LobbySetResolution()
    {
        canvasScaler = FindObjectOfType<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);

        Debug.Log(ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_WIDTH));
        Debug.Log(ResolutionData.Instance.GetData(RESOLUTION_DATA.RESOLUTION_HEIGHT));
    }
}
