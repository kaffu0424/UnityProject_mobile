using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    // �ػ� Ȯ�ο� �׽�Ʈ ��ũ��Ʈ
    public TextMeshProUGUI text_0_0;
    public TextMeshProUGUI text_1_1;
    void Start()
    {
        text_0_0.text = "0,0";
        text_1_1.text = GetComponent<CanvasScaler>().referenceResolution.x + "," + GetComponent<CanvasScaler>().referenceResolution.y;
    }
}
