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
}
