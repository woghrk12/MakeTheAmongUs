using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameRoomPanelType
{ 
    MainUI, SettingUI, CustomUI, None
}

public class GameRoomUIManager : MonoBehaviour
{
    public static GameRoomUIManager instance;

    [SerializeField] private List<GameObject> panelList;

    private void Awake()
    {
        instance = this;
    }
}
