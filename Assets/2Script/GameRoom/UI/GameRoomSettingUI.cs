using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoomSettingUI : SettingUI
{
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClickReturnToGameButton()
    {
        CloseSettingUI();
    }

    public void OnClickExitGameRoomButton()
    {
        ExitGameRoom();
    }

    private void ExitGameRoom()
    {
        AmongUsNetworkManager.Instance.Disconnect();

        SceneManager.LoadScene("MainMenu");
    }
}
