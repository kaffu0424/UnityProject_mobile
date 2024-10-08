using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResolutionData : Singleton<ResolutionData>
{
    private float[] data;

    public ResolutionData()
    {
        // ����Ʈ �ʱ�ȭ
        data = new float[Enum.GetValues(typeof(RESOLUTION_DATA)).Length];
    }

    public float GetData(RESOLUTION_DATA _type)
    {
        return data[(int)_type];
    }

    public void SetData(RESOLUTION_DATA _type, float _data)
    {
        data[(int)_type] = _data;
    }
}
