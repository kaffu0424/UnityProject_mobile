using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResolutionData : Singleton<ResolutionData>
{
    private float[] m_data;

    public ResolutionData()
    {
        // 리스트 초기화
        m_data = new float[Enum.GetValues(typeof(RESOLUTION_DATA)).Length];
    }

    public float GetData(RESOLUTION_DATA _type)
    {
        return m_data[(int)_type];
    }

    public void SetData(RESOLUTION_DATA _type, float _data)
    {
        m_data[(int)_type] = _data;
    }
}
