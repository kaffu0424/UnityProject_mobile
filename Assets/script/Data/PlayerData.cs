using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerInformation
{
    public int cost;        // ���� ��ȭ

    // ���� ���׷��̵� ��ġ
    public int upgrade_1;
    public int upgrade_2;
    public int upgrade_3;
    public int upgrade_4;

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

    public void CreateData()
    {
        // ������ ����
        data = new PlayerInformation();
        // ������ -> Json ��ȯ
        string jsonData = JsonUtility.ToJson(data);
        // PlayerPrefs�� Ȱ���Ͽ� ������ ����
        PlayerPrefs.SetString(dataKey, jsonData);
    }

    public void SaveData()
    {
        if(data == null)
        {
            // �����Ͱ� ������ ������ ����
            data = new PlayerInformation();
        }

        // ������ -> Json ��ȯ
        string jsonData = JsonUtility.ToJson(data);
        // PlayerPrefs�� Ȱ���Ͽ� ������ ����
        PlayerPrefs.SetString(dataKey, jsonData);
    }
}
