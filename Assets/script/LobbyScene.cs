using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
    private void Awake()
    {
        // PlayerPrefs.DeleteKey("PlayerData");

        //������ �ҷ�����
        if (!LocalLogin.Instance.LoadData())
        {
            // �����ϸ� ���� ����
            Application.Quit();
        }

        Debug.Log(LocalLogin.Instance.playerData.name);
    }
}
