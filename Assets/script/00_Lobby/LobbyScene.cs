using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public enum LocalizationType
{
    English = 0,
    Korean = 1,
}

// Lobby Scene�� �����ϴ� �ھ� ��ũ��Ʈ
public class LobbyScene : Singleton_Mono<LobbyScene>
{
    protected override void InitializeManager()
    {
        // �κ� �� �ػ� ����
        LobbySetResolution();

        // ���� ������ �ε�
        LoadData();
    }

    private void LoadData()
    {
        // ������ �ʱ�ȭ
        // �÷��̾� �����Ϳ� ���� �߰��ɶ����� �ѹ� ��������ֱ�!
        // PlayerPrefs.DeleteKey("PlayerData");

        //������ �ҷ�����
        if (!PlayerData.Instance.LoadData())
        {
            // �����ϸ� ���� ����
            Application.Quit();
        }
    }

    private void LobbySetResolution()
    {
        FindObjectOfType<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);

        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // ȭ�� ����
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);
    }

    #region Localization �׽�Ʈ �ڵ�
    public void kor()
    {
        ChangeLanguage(LocalizationType.Korean);
    }

    public void eng()
    {
        ChangeLanguage(LocalizationType.English);
    }
    private void ChangeLanguage(LocalizationType languageType)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[(int)languageType];
    }
    #endregion
}

