using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_title;        // �˾� Ÿ��Ʋ
    [SerializeField] private TextMeshProUGUI m_description;  // �˾� ����

    [SerializeField] private Button m_yesButton;             // �˾� YES ��ư
    [SerializeField] private Button m_noButton;              // �˾� NO ��ư

    private void Start()
    {
        m_noButton.onClick.AddListener(() => NoButtonFunction());
    }

    public void SetText(string _title, string _description)
    {
        // �ؽ�Ʈ ������Ʈ
        m_title.text = _title;
        m_description.text = _description;
    }

    public void SetButtonFunction(Action _yesFunc)
    {
        m_yesButton.onClick.RemoveAllListeners();           // Ŭ�� �̺�Ʈ ����
        m_yesButton.onClick.AddListener(() => _yesFunc());  // Ŭ�� �̺�Ʈ ���ε�
    }

    private void NoButtonFunction()
    {
        gameObject.SetActive(false);    // �˾� �ݱ�
    }
}
