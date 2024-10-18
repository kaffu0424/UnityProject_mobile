using System.Collections;
using TMPro;
using UnityEngine;

public class LobbyErrorUI : MonoBehaviour
{
    public TextMeshProUGUI m_errorTEXT;

    public IEnumerator OnMessage(string _text, float _time)
    {
        // 텍스트 변경
        m_errorTEXT.text = _text;

        // FadeOut 코루틴이 끝날때까지 대기
        yield return StartCoroutine(FadeOut(_time));

        // 오브젝트 비활성화
        gameObject.SetActive(false);
    }
    
    IEnumerator FadeOut(float _time)
    {
        // 색 초기화
        m_errorTEXT.color = Color.white;

        // _time 만큼 대기
        yield return new WaitForSeconds(_time);

        // alpha값
        float colorAlpha = 1;

        while (colorAlpha > 0.05f)                   // alpha값이 0.05이하가 될때까지
        {
            // 컬러 알파값 감소
            colorAlpha -= 0.02f;

            // 컬러 알파값 변경
            Color newColor = m_errorTEXT.color;
            newColor.a = colorAlpha;
            m_errorTEXT.color = newColor;

            // 대기
            yield return new WaitForSeconds(0.03f);
        }

        // 다음 호출때 텍스트가 보이지않도록 처리
        m_errorTEXT.color = new Color(0, 0, 0, 0);
    }
}
