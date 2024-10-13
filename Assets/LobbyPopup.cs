using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_title;        // 팝업 타이틀
    [SerializeField] private TextMeshProUGUI m_description;  // 팝업 설명

    [SerializeField] private Button m_YESButton;             // 팝업 YES 버튼
    [SerializeField] private Button m_NoButton;              // 팝업 NO 버튼

    public void SetText(string _title, string _description)
    {
        // 텍스트 업데이트
        m_title.text = _title;
        m_description.text = _description;
    }
}
