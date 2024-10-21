using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyOption : MonoBehaviour
{
    private Button m_backButton;

    private void Start()
    {
        // �ݱ� ��ư ������Ʈ
        m_backButton = GetComponentInChildren<Button>();

        // ��ư �̺�Ʈ ���ε�
        m_backButton.onClick.AddListener(() => BackButtonFunction());
    }



    private void BackButtonFunction()
    {
        gameObject.SetActive(false);
    }
}
