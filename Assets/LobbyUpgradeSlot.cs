using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyUpgradeSlot : MonoBehaviour
{
    private UPGRADE_TYPE m_upgradeType;
    public UPGRADE_TYPE upgradeIndex 
    { get { return m_upgradeType; } set { m_upgradeType = value; } }

    [SerializeField] private TextMeshProUGUI m_skillLevelText;

    public void UpdateData()
    {
        m_skillLevelText.text =
            "LV. " + PlayerData.Instance.data.upgradeInfo[(int)m_upgradeType];
    }
}
