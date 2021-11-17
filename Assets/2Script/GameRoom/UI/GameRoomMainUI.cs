using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomMainUI : MonoBehaviour
{
    [SerializeField] private GameObject gameRoomSettingUI;

    public void OnClickSettingButton()
    {
        ActiveSettingUI();
    }

    private void ActiveSettingUI()
    {
        gameRoomSettingUI.SetActive(true);
    }
}
