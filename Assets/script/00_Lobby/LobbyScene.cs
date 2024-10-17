using UnityEngine;
using UnityEngine.UI;

// Lobby Scene을 관리하는 코어 스크립트
public class LobbyScene : Singleton_Mono<LobbyScene>
{
    protected override void InitializeManager()
    {
        // 로비 씬 해상도 설정
        LobbySetResolution();

        // 로컬 데이터 로드
        LoadData();
    }

    private void LoadData()
    {
        // 데이터 초기화
        // 플레이어 데이터에 뭔가 추가될때마다 한번 실행시켜주기!
        // PlayerPrefs.DeleteKey("PlayerData");

        //데이터 불러오기
        if (!PlayerData.Instance.LoadData())
        {
            // 실패하면 게임 끄기
            Application.Quit();
        }
    }

    private void LobbySetResolution()
    {
        FindObjectOfType<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);

        // 화면 길이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_WIDTH, Screen.width);
        // 화면 높이
        ResolutionData.Instance.SetData(RESOLUTION_DATA.RESOLUTION_HEIGHT, Screen.height);
    }

    #region Localization 테스트
    public void kor()
    {
        Localization.Instance.ChangeKOR();
    }

    public void eng()
    {
        Localization.Instance.ChangeENG();
    }
    #endregion
}

