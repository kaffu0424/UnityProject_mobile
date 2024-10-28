using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";

    private Dictionary<string, string> m_stringData;

    public void InitStringData()
    {
        if(m_stringData == null)
        {
            m_stringData = new Dictionary<string, string>();
        
            // 엑셀 데이터 파싱
            TextAsset data = Resources.Load("StringData") as TextAsset;

            // 줄단위로 자르기
            var lines = Regex.Split(data.text, LINE_SPLIT_RE);  
            var header = Regex.Split(lines[0], SPLIT_RE);      

            for (int i = 1; i < lines.Length; i++)
            {
                // 단어로 자르고 데이터 저장
                var values = Regex.Split(lines[i], SPLIT_RE);   
                m_stringData.Add(values[0], values[1]);         
            }
        }
    }

    public string GetKORString(string _key)
    {
        string ret;
        if(m_stringData.TryGetValue(_key, out ret))
        {
            return ret;
        }
        return _key;
    }

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
    public void ChangeLanguage(LocalizationType _languageType)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[(int)_languageType];
    }
}
