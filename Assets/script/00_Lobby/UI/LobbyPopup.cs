using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_title;        // 팝업 타이틀
    [SerializeField] private TextMeshProUGUI m_description;  // 팝업 설명

    [SerializeField] private Button m_yesButton;             // 팝업 YES 버튼
    [SerializeField] private Button m_noButton;              // 팝업 NO 버튼

    private void Start()
    {
        m_noButton.onClick.AddListener(() => NoButtonFunction());
    }

    public void SetText(string _title, string _description)
    {
        // 텍스트 업데이트
        m_title.text = _title;
        m_description.text = _description;
    }

    public void SetButtonFunction(Action _yesFunc)
    {
        m_yesButton.onClick.RemoveAllListeners();           // 클릭 이벤트 제거
        m_yesButton.onClick.AddListener(() => _yesFunc());  // 클릭 이벤트 바인딩
    }

    private void NoButtonFunction()
    {
        gameObject.SetActive(false);    // 팝업 닫기
    }
}
