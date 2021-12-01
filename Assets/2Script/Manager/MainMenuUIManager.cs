using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMainMenuPanelType
{ 
    MainUI, SettingUI, OnlineUI, CreateRoomUI, JoinRoomUI, None
}

public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager instance;

    [SerializeField] private List<GameObject> panelList;
    
    private void Awake()
    {
        instance = this;
    }

    public void ChangeUI(EMainMenuPanelType openPanel, EMainMenuPanelType closePanel = EMainMenuPanelType.None)
    {
        if(closePanel != EMainMenuPanelType.None)
            panelList[(int)closePanel].SetActive(false);
        panelList[(int)openPanel].SetActive(true);
    }
}
