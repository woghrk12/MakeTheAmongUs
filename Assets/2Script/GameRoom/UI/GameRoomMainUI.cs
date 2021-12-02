using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomMainUI : MonoBehaviour
{
    public void OnClickSettingButton()
    {
        ActiveSettingUI();
    }

    private void ActiveSettingUI()
    {
        GameRoomUIManager.instance.OpenSettingUI();
    }
}
