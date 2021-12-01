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

    public void OpenPanel(EMainMenuPanelType panel)
    {
        panelList[(int)panel].SetActive(true);
    }

    public void ClosePanel(EMainMenuPanelType panel)
    {
        panelList[(int)panel].SetActive(false);
    }
}
