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

    private void OpenPanel(EMainMenuPanelType panel) => panelList[(int)panel].SetActive(true);
    private void ClosePanel(EMainMenuPanelType panel) => panelList[(int)panel].SetActive(false);

    #region UIOnFunction

    public void OpenMainUI() => OpenPanel(EMainMenuPanelType.MainUI);
    public void OpenSettingUI() => OpenPanel(EMainMenuPanelType.SettingUI);
    public void OpenOnlineUI() => OpenPanel(EMainMenuPanelType.OnlineUI);
    public void OpenCreateRoomUI() => OpenPanel(EMainMenuPanelType.CreateRoomUI);
    public void OpenJoinRoomUI() => OpenPanel(EMainMenuPanelType.JoinRoomUI);

    #endregion
    #region UIOffFunction

    public void CloseMainUI() => ClosePanel(EMainMenuPanelType.MainUI);
    public void CloseSettingUI() => ClosePanel(EMainMenuPanelType.SettingUI);
    public void CloseOnlineUI() => ClosePanel(EMainMenuPanelType.OnlineUI);
    public void CloseCreateRoomUI() => ClosePanel(EMainMenuPanelType.CreateRoomUI);
    public void CloseJoinRoomUI() => ClosePanel(EMainMenuPanelType.JoinRoomUI);

    #endregion
}
