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
        
            // ���� ������ �Ľ�
            TextAsset data = Resources.Load("StringData") as TextAsset;

            // �ٴ����� �ڸ���
            var lines = Regex.Split(data.text, LINE_SPLIT_RE);  
            var header = Regex.Split(lines[0], SPLIT_RE);      

            for (int i = 1; i < lines.Length; i++)
            {
                // �ܾ�� �ڸ��� ������ ����
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
    public void ChangeLanguage(LocalizationType _languageType)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[(int)_languageType];
    }
}
