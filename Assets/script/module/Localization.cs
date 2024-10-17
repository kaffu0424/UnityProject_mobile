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
        // 현재 언어 변경
        PlayerData.Instance.data.localization = LocalizationType.KOR; 
        // 언어 변경
        ChangeLanguage(PlayerData.Instance.data.localization);
        // 언어 저장
        PlayerData.Instance.SaveData();
    }

    public void ChangeENG()
    {
        // 현재 언어 변경
        PlayerData.Instance.data.localization = LocalizationType.ENG;
        // 언어 변경
        ChangeLanguage(PlayerData.Instance.data.localization);
        // 언어 저장
        PlayerData.Instance.SaveData();
    }
    private void ChangeLanguage(LocalizationType _languageType)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[(int)_languageType];
    }
}
