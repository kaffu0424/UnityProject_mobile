using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESOLUTION_DATA
{
    RESOLUTION_WIDTH,       // 해상도 길이
    RESOLUTION_HEIGHT,      // 해상도 높이
    UIRECT_WIDTH,           // UI 영역 길이
    UIRECT_HEIGHT,          // UI 영역 높이
    CAMERARECT_WIDTH,       // 게임카메라 영역 길이
    CAMERARECT_HEIGHT,      // 게임카메라 영역 높이
}

// 스프라이트 이름으로 넣어주기
public enum SPRITE_DATA
{
    // 업그레이드 스프라이트
    SPRITE_MaxHP,
    SPRITE_Damage,
    SPRITE_AttackSpeed,
    SPRITE_Critical,
    SPRITE_Defense,
    SPRITE_Slow,
    SPRITE_Coin,
    SPRITE_Slot,
    SPRITE_Lucky,
}