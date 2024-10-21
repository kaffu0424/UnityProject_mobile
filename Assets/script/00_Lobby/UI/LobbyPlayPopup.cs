using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyPlayPopup : MonoBehaviour
{
    private const float defaultDifficultyValue = 0.3f;

    [SerializeField] private Slider m_difficultySlider;        // 난이도 배율 슬라이드바
    [SerializeField] private TextMeshProUGUI m_difficultyMultiple;        // 난이도 배율 텍스트

    [SerializeField] private Button m_playButton;             // 팝업 YES 버튼
    [SerializeField] private Button m_cancleButton;              // 팝업 NO 버튼
    private void Start()
    {
        m_difficultySlider.onValueChanged.AddListener(delegate { UpdateDifficulty(); } );

        m_playButton.onClick.AddListener(() => PlayButtonFunction());
        m_cancleButton.onClick.AddListener(() => CancleButtonFunction());
    }

    private void UpdateDifficulty()
    {
        // 기본값
        float value = m_difficultySlider.value + 0.7f;  // 배율 기본값
        value *= value + (Mathf.Log10(value)*2);        // 배율 연산 ( 0.27 ~ 3.67 )
        value = (float)Math.Round(value, 2);            // 배율 반올림

        PlayerData.Instance.data.currentDifficulty = value; // 배율 적용

        m_difficultyMultiple.text = "x " + value;       // 배율 텍스트 업데이트
    }

    private void PlayButtonFunction()
    {
        // 게임 시작
        SceneManager.LoadScene("01_Main");
    }
    private void CancleButtonFunction()
    {
        m_difficultySlider.value = defaultDifficultyValue;  // 슬라이더 기본값 설정
        PlayerData.Instance.data.currentDifficulty = 0;     // 배율 초기화
        m_difficultyMultiple.text = "x " + 1.0;             // 배율 텍스트 초기화

        gameObject.SetActive(false);                        // 팝업 닫기
    }
}
