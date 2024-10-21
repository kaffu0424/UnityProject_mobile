using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyOption : MonoBehaviour
{
    private Button m_backButton;

    private void Start()
    {
        // 닫기 버튼 컴포넌트
        m_backButton = GetComponentInChildren<Button>();

        // 버튼 이벤트 바인딩
        m_backButton.onClick.AddListener(() => BackButtonFunction());
    }



    private void BackButtonFunction()
    {
        gameObject.SetActive(false);
    }
}
