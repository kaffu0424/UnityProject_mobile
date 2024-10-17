using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public enum LocalizationType
{
    ENG = 0,
    KOR = 1,
}
public class Localization : Singleton<Localization>
{
    public void ChangeKOR()
    {
        // ���� ��� ����
        PlayerData.Instance.data.localization = LocalizationType.KOR; 
        // ��� ����
        ChangeLanguage(PlayerData.Instance.data.localization);
        // ��� ����
        PlayerData.Instance.SaveData();
    }

    public void ChangeENG()
    {
        // ���� ��� ����
        PlayerData.Instance.data.localization = LocalizationType.ENG;
        // ��� ����
        ChangeLanguage(PlayerData.Instance.data.localization);
        // ��� ����
        PlayerData.Instance.SaveData();
    }
    private void ChangeLanguage(LocalizationType _languageType)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[(int)_languageType];
    }
}
