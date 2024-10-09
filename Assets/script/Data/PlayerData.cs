using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerInformation
{
    public int cost;        // 보유 재화

    // 각종 업그레이드 수치
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
        // 데이터 있음
        if (PlayerPrefs.HasKey(dataKey))
        {
            // PlayerPrefs를 활용하여 데이터 불러오기
            string jsonData = PlayerPrefs.GetString(dataKey);

            // Json -> 데이터 변환 및 적용
            data = JsonUtility.FromJson<PlayerInformation>(jsonData);
        }
        // 데이터 없음
        else
        {
            // 데이터 생성 및 저장
            SaveData();
        }

        // 데이터가 정상적으로 들어왔는지 확인
        if (data == null)
            return false;
        return true;
    }

    public void CreateData()
    {
        // 데이터 생성
        data = new PlayerInformation();
        // 데이터 -> Json 변환
        string jsonData = JsonUtility.ToJson(data);
        // PlayerPrefs를 활용하여 데이터 저장
        PlayerPrefs.SetString(dataKey, jsonData);
    }

    public void SaveData()
    {
        if(data == null)
        {
            // 데이터가 없으면 데이터 생성
            data = new PlayerInformation();
        }

        // 데이터 -> Json 변환
        string jsonData = JsonUtility.ToJson(data);
        // PlayerPrefs를 활용하여 데이터 저장
        PlayerPrefs.SetString(dataKey, jsonData);
    }
}
