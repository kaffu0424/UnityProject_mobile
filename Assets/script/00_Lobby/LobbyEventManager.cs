using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyEventManager : MonoBehaviour
{
    private LobbyScene m_Lobby;
    public LobbyScene lobbyScene { get { return m_Lobby; } set { m_Lobby = value; } }

    public void ExitGame()
    {
        Application.Quit();
    }
}
