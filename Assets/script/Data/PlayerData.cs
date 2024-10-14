using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    // data
    public float m_currentDifficulty;     // ���� ������ ���̵� ( ���� ���� )
    public int m_cost;                    // ���� ��ȭ
    public List<int> m_upgradeInfo;        // ���� ���׷��̵� ��ġ

    // get/set
    public float currentDifficulty
    { get { return m_currentDifficulty; } set {  m_currentDifficulty = value; } }
    public int cost 
    { get { return m_cost;} set { m_cost = value; } }
    public List<int> upgradeInfo 
    { get { return m_upgradeInfo; } }

    // function
    public void InitUpgradeInfo()
    {
        m_upgradeInfo = new List<int>();
        for(int i = 0; i < Enum.GetValues(typeof(UPGRADE_TYPE)).Length; i++)
        {
            m_upgradeInfo.Add(0);
        }
    }
}

public class PlayerData : Singleton<PlayerData>
{
    private const string dataKey = "PlayerData";
    public PlayerInformation data;

    public bool LoadData()
    {
        // ������ ����
        if (PlayerPrefs.HasKey(dataKey))
        {
            // PlayerPrefs�� Ȱ���Ͽ� ������ �ҷ�����
            string jsonData = PlayerPrefs.GetString(dataKey);

            // Json -> ������ ��ȯ �� ����
            data = JsonUtility.FromJson<PlayerInformation>(jsonData);
        }
        // ������ ����
        else
        {
            // ������ ���� �� ����
            SaveData();
        }

        // �����Ͱ� ���������� ���Դ��� Ȯ��
        if (data == null)
            return false;
        return true;
    }

    public void SaveData()
    {
        if(data == null)
        {
            // �����Ͱ� ������ ������ ����
            data = new PlayerInformation();

            // �迭 ����
            data.InitUpgradeInfo();
        }

        // ������ -> Json ��ȯ
        string jsonData = JsonUtility.ToJson(data);
        // PlayerPrefs�� Ȱ���Ͽ� ������ ����
        PlayerPrefs.SetString(dataKey, jsonData);
    }
}
