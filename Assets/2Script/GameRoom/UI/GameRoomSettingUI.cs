using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnClickExitGameButton()
    {
        ExitGame();
    }

    private void ExitGame()
    {
        AmongUsNetworkManager.Instance.Disconnect();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
