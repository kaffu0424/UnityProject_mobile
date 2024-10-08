using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
    private void Awake()
    {
        // PlayerPrefs.DeleteKey("PlayerData");

        //데이터 불러오기
        if (!LocalLogin.Instance.LoadData())
        {
            // 실패하면 게임 끄기
            Application.Quit();
        }

        Debug.Log(LocalLogin.Instance.playerData.name);
    }
}
