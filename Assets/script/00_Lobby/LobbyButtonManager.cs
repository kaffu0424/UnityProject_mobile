using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum LobbyButton
{
    LOBBY_PLAY,
    LOBBY_UPGRADE,
    LOBBY_OPTION,
    LOBBY_EXIT,
}

public class LobbyButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> lobbyButtons;

    private void Start()
    {
        lobbyButtons[(int)LobbyButton.LOBBY_PLAY].onClick.AddListener(() => PlayButton());
        lobbyButtons[(int)LobbyButton.LOBBY_UPGRADE].onClick.AddListener(() => PlayButton());
        lobbyButtons[(int)LobbyButton.LOBBY_OPTION].onClick.AddListener(() => PlayButton());
        lobbyButtons[(int)LobbyButton.LOBBY_EXIT].onClick.AddListener(() => PlayButton());
    }

    private void PlayButton()
    {
        // ���� ����
        SceneManager.LoadScene(1);
    }

    private void UpgradeButton()
    {
        // 1. ���׷��̵� �˾�
    }
    private void OptionButton()
    {
        // 1. �ɼ� �˾�
    }
    private void ExitButton()
    {
        // 1. ���� �˾� ����
        // 2. yes : ���� ����
        // 3. no : �˾� �ݱ�
    }
}
