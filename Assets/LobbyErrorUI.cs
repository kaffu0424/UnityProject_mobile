using System.Collections;
using TMPro;
using UnityEngine;

public class LobbyErrorUI : MonoBehaviour
{
    public TextMeshProUGUI m_errorTEXT;

    public IEnumerator OnMessage(string _text, float _time)
    {
        // �ؽ�Ʈ ����
        m_errorTEXT.text = _text;

        // FadeOut �ڷ�ƾ�� ���������� ���
        yield return StartCoroutine(FadeOut(_time));

        // ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
    
    IEnumerator FadeOut(float _time)
    {
        // �� �ʱ�ȭ
        m_errorTEXT.color = Color.white;

        // _time ��ŭ ���
        yield return new WaitForSeconds(_time);

        // alpha��
        float colorAlpha = 1;

        while (colorAlpha > 0.05f)                   // alpha���� 0.05���ϰ� �ɶ�����
        {
            // �÷� ���İ� ����
            colorAlpha -= 0.02f;

            // �÷� ���İ� ����
            Color newColor = m_errorTEXT.color;
            newColor.a = colorAlpha;
            m_errorTEXT.color = newColor;

            // ���
            yield return new WaitForSeconds(0.03f);
        }

        // ���� ȣ�⶧ �ؽ�Ʈ�� �������ʵ��� ó��
        m_errorTEXT.color = new Color(0, 0, 0, 0);
    }
}
