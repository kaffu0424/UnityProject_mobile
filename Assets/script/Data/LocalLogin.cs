using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData
{
    public int cost;        // ���� ��ȭ
    public string name;     // �÷��̾� �г��� ( �ӽ�

    // ���� ���׷��̵� ��ġ
    public int upgrade_1;
    public int upgrade_2;
    public int upgrade_3;
    public int upgrade_4;

    public PlayerData(string _name)
    {
        name = _name;
    }
}

public class LocalLogin : Singleton<LocalLogin>
{
    private const string dataKey        = "PlayerData";
    public PlayerData playerData;

    // 1. ������ ���������  �÷��̾��� �����͸� �ҷ���(������ ����)
    public bool LoadData()
    {
        // ������ ����
        if(PlayerPrefs.HasKey(dataKey))
        {
            string jsonData = PlayerPrefs.GetString(dataKey);           // PlayerPrefs�� Ȱ���Ͽ� ������ �ҷ�����
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);    // Json -> ������ ��ȯ �� ����
        }   
        // ������ ����
        else
        {
            // ������ ����
            CreateData();
        }

        // �����Ͱ� ���������� ���Դ��� Ȯ��
        if (playerData == null)
            return false;
        return true;
    }

    public void CreateData()
    {
        playerData = new PlayerData("player_1");              // ������ ����
        string jsonData = JsonUtility.ToJson(playerData);   // ������ -> Json ��ȯ
        PlayerPrefs.SetString(dataKey, jsonData);           // PlayerPrefs�� Ȱ���Ͽ� ������ ����
    }
}
