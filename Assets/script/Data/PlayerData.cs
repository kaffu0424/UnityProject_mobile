using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    // data
    public float m_currentDifficulty;     // 현재 게임의 난이도 ( 보상 배율 )
    public int m_cost;                    // 보유 재화
    public List<int> m_upgradeInfo;        // 각종 업그레이드 수치

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

    public void SaveData()
    {
        if(data == null)
        {
            // 데이터가 없으면 데이터 생성
            data = new PlayerInformation();

            // 배열 세팅
            data.InitUpgradeInfo();
        }

        // 데이터 -> Json 변환
        string jsonData = JsonUtility.ToJson(data);
        // PlayerPrefs를 활용하여 데이터 저장
        PlayerPrefs.SetString(dataKey, jsonData);
    }
}
