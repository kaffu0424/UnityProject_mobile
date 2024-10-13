using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_title;        // �˾� Ÿ��Ʋ
    [SerializeField] private TextMeshProUGUI m_description;  // �˾� ����

    [SerializeField] private Button m_YESButton;             // �˾� YES ��ư
    [SerializeField] private Button m_NoButton;              // �˾� NO ��ư

    public void SetText(string _title, string _description)
    {
        // �ؽ�Ʈ ������Ʈ
        m_title.text = _title;
        m_description.text = _description;
    }
}
