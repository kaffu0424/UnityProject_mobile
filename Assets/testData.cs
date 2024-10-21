using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testData : MonoBehaviour
{
    public PlayerInformation testInfo;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        testInfo = PlayerData.Instance.data;

        //PlayerData.Instance.data.upgradeInfo[(int)UPGRADE_TYPE.DAMAGE] = 2;
        //PlayerData.Instance.SaveData();


    }
}
