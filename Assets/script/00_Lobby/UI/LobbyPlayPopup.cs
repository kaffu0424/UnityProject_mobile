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

    [SerializeField] private Slider m_difficultySlider;        // ���̵� ���� �����̵��
    [SerializeField] private TextMeshProUGUI m_difficultyMultiple;        // ���̵� ���� �ؽ�Ʈ

    [SerializeField] private Button m_playButton;             // �˾� YES ��ư
    [SerializeField] private Button m_cancleButton;              // �˾� NO ��ư
    private void Start()
    {
        m_difficultySlider.onValueChanged.AddListener(delegate { UpdateDifficulty(); } );

        m_playButton.onClick.AddListener(() => PlayButtonFunction());
        m_cancleButton.onClick.AddListener(() => CancleButtonFunction());
    }

    private void UpdateDifficulty()
    {
        // �⺻��
        float value = m_difficultySlider.value + 0.7f;  // ���� �⺻��
        value *= value + (Mathf.Log10(value)*2);        // ���� ���� ( 0.27 ~ 3.67 )
        value = (float)Math.Round(value, 2);            // ���� �ݿø�

        PlayerData.Instance.data.currentDifficulty = value; // ���� ����

        m_difficultyMultiple.text = "x " + value;       // ���� �ؽ�Ʈ ������Ʈ
    }

    private void PlayButtonFunction()
    {
        // ���� ����
        SceneManager.LoadScene("01_Main");
    }
    private void CancleButtonFunction()
    {
        m_difficultySlider.value = defaultDifficultyValue;  // �����̴� �⺻�� ����
        PlayerData.Instance.data.currentDifficulty = 0;     // ���� �ʱ�ȭ
        m_difficultyMultiple.text = "x " + 1.0;             // ���� �ؽ�Ʈ �ʱ�ȭ

        gameObject.SetActive(false);                        // �˾� �ݱ�
    }
}
