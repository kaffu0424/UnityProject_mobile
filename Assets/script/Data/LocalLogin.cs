using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData
{
    public int cost;        // 보유 재화
    public string name;     // 플레이어 닉네임 ( 임시

    // 각종 업그레이드 수치
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

    // 1. 게임이 실행됐을때  플레이어의 데이터를 불러옴(없으면 생성)
    public bool LoadData()
    {
        // 데이터 있음
        if(PlayerPrefs.HasKey(dataKey))
        {
            string jsonData = PlayerPrefs.GetString(dataKey);           // PlayerPrefs를 활용하여 데이터 불러오기
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);    // Json -> 데이터 변환 및 적용
        }   
        // 데이터 없음
        else
        {
            // 데이터 생성
            CreateData();
        }

        // 데이터가 정상적으로 들어왔는지 확인
        if (playerData == null)
            return false;
        return true;
    }

    public void CreateData()
    {
        playerData = new PlayerData("player_1");              // 데이터 생성
        string jsonData = JsonUtility.ToJson(playerData);   // 데이터 -> Json 변환
        PlayerPrefs.SetString(dataKey, jsonData);           // PlayerPrefs를 활용하여 데이터 저장
    }
}
