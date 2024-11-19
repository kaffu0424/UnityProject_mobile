using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton_Mono<GameManager>
{
    public Camera m_gameCamera;               // 테스트
    public List<GameObject> m_testObjects;    // 테스트
    protected override void InitializeManager()
    {
        //{ 
        //    Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[0].transform.position);
        //    pos1.x = 0; pos1.y = 0;
        //    m_testObjects[0].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        //}
        //{
        //    Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[1].transform.position);
        //    pos1.x = 0; pos1.y = 1;
        //    m_testObjects[1].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        //}
        //{
        //    Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[2].transform.position);
        //    pos1.x = 1; pos1.y = 1;
        //    m_testObjects[2].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        //}
        //{
        //    Vector3 pos1 = m_gameCamera.WorldToViewportPoint(m_testObjects[3].transform.position);
        //    pos1.x = 1; pos1.y = 0;
        //    m_testObjects[3].transform.position = m_gameCamera.ViewportToWorldPoint(pos1);
        //}
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryManager.Instance.GetItem((ItemName)Random.Range(0, 2));   
        }
    }


    /*  게임 사이클
     *  1. 로비씬에서 강화 및 업그레이드
     *  2. 로비씬 -> 난이도설정 -> 게임씬
     *  3. 게임 진행
     *  4. 게임 종료시 난이도 및 플레이에 따른 보상 지급 ( 강화/업그레이드 할수있는 코인 )
     *  5. 데이터 저장
     *  6. 로딩창 띄우고 2-3초 정도 기다렸다가 로비씬으로 돌아가기
     */

    /* 몬스터
     * 1. 기본 스탯 + 시간이 지남에 따라 증가하는 스탯 + 난이도에 맞춰 증가하는 스탯
     * 2. 오른쪽끝에서 출발하여 플레이어에게 다가가 공격
     */

    /* 플레이어
     * 1. 뽑기를 통해 아이템 뽑기 ( 창고[하단 슬롯] 로 이동 )
     * 2. 창고에 있는 아이템을 인벤토리[상단 슬롯]에 넣어 공격 ( grid Inventory )
     */

    /* 아이템
     * 1. 공격 아이템
     *  1-1. 무기마다 기본 공격력 및 공속
     *  1-2. 플레이어의 강화수치에 따라 스탯 증가
     * 2. 버프 아이템 ( 공증 공속증 등등 )
     *  2-1. 그냥 버프아이템
     * 3. 합성
     *  3-1. 같은 아이템위에 드래그했을때 상위 아이템으로 업그레이드
     */

    /* 뽑기
     * 1. 창고의 남은 사이즈에 들어갈수있는 아이템중 랜덤 뽑기
     */

    /* 창고
     * 1. 2*6 사이즈의 인벤토리 슬롯
     * 2. 해당 슬롯에있는 아이템은 공격안함
     * 3. 아이템을 같은 아이템위에 올리면 업그레이드
     */

    /* 인벤토리
     * 1. 3*3 사이즈의 인벤토리 슬롯
     * 2. 해당 슬롯에있는 아이템을 통해 공격
     * 3. 아이템을 같은 아이템위에 올리면 업그레이드
     */

    #region test
    public void backlobby()
    {
        PlayerData.Instance.data.cost += 100;   // 코인 추가
        PlayerData.Instance.SaveData();
        SceneManager.LoadScene("00_Lobby");     // 로비씬으로 돌아가기
    }
    #endregion
}
