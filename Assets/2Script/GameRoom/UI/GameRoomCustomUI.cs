using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomCustomUI : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void OnClickBackground()
    {
        CloseCustomUI();
    }

    private void CloseCustomUI()
    {
        GameRoomUIManager.instance.OpenMainUI();
        GameRoomUIManager.instance.CloseCustomUI();
    }
}

