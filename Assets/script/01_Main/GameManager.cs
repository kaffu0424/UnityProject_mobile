using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton_Mono<GameManager>
{
    public Camera m_gameCamera;               // �׽�Ʈ
    public List<GameObject> m_testObjects;    // �׽�Ʈ
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


    /*  ���� ����Ŭ
     *  1. �κ������ ��ȭ �� ���׷��̵�
     *  2. �κ�� -> ���̵����� -> ���Ӿ�
     *  3. ���� ����
     *  4. ���� ����� ���̵� �� �÷��̿� ���� ���� ���� ( ��ȭ/���׷��̵� �Ҽ��ִ� ���� )
     *  5. ������ ����
     *  6. �ε�â ���� 2-3�� ���� ��ٷȴٰ� �κ������ ���ư���
     */

    /* ����
     * 1. �⺻ ���� + �ð��� ������ ���� �����ϴ� ���� + ���̵��� ���� �����ϴ� ����
     * 2. �����ʳ����� ����Ͽ� �÷��̾�� �ٰ��� ����
     */

    /* �÷��̾�
     * 1. �̱⸦ ���� ������ �̱� ( â��[�ϴ� ����] �� �̵� )
     * 2. â�� �ִ� �������� �κ��丮[��� ����]�� �־� ���� ( grid Inventory )
     */

    /* ������
     * 1. ���� ������
     *  1-1. ���⸶�� �⺻ ���ݷ� �� ����
     *  1-2. �÷��̾��� ��ȭ��ġ�� ���� ���� ����
     * 2. ���� ������ ( ���� ������ ��� )
     *  2-1. �׳� ����������
     * 3. �ռ�
     *  3-1. ���� ���������� �巡�������� ���� ���������� ���׷��̵�
     */

    /* �̱�
     * 1. â���� ���� ����� �����ִ� �������� ���� �̱�
     */

    /* â��
     * 1. 2*6 �������� �κ��丮 ����
     * 2. �ش� ���Կ��ִ� �������� ���ݾ���
     * 3. �������� ���� ���������� �ø��� ���׷��̵�
     */

    /* �κ��丮
     * 1. 3*3 �������� �κ��丮 ����
     * 2. �ش� ���Կ��ִ� �������� ���� ����
     * 3. �������� ���� ���������� �ø��� ���׷��̵�
     */

    #region test
    public void backlobby()
    {
        PlayerData.Instance.data.cost += 100;   // ���� �߰�
        PlayerData.Instance.SaveData();
        SceneManager.LoadScene("00_Lobby");     // �κ������ ���ư���
    }
    #endregion
}
