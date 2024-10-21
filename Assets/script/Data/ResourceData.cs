using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceData : Singleton<ResourceData>
{
    private Dictionary<string, Sprite> m_spriteData;

    public void LoadData()
    {
        // Sprite load
        if (m_spriteData == null)
            LoadSprite();

        // --- load

        // --- load
    }

    private void LoadSprite()
    {
        // SpriteData �ʱ�ȭ
        m_spriteData = new Dictionary<string, Sprite>();

        // enum SpriteData ��ŭ �ݺ���
        int spriteLength = Enum.GetValues(typeof(SPRITE_DATA)).Length;
        for (int i = 0; i < spriteLength; i++)
        {
            string fileName = ((SPRITE_DATA)i).ToString();

            Sprite sprite = Resources.Load<Sprite>($"Sprite/{fileName}");
            m_spriteData.Add(fileName, sprite);
        }
    }

    public Sprite GetSprite(string _key)
    {
        if(m_spriteData.TryGetValue(_key, out Sprite sprite))
            return sprite;

        Debug.Log("����!");
        return null;
    }
}
