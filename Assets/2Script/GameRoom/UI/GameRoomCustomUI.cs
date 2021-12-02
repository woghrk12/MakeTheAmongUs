using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomCustomUI : MonoBehaviour
{
    public void OnClickBackground()
    {
        CloseCustomUI();
    }

    private void CloseCustomUI()
    {
        GameRoomUIManager.instance.OpenPanel(EGameRoomPanelType.MainUI);
        GameRoomUIManager.instance.ClosePanel(EGameRoomPanelType.CustomUI);
    }
}

