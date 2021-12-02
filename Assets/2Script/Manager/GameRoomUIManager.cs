using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum EGameRoomPanelType
{ 
    MainUI, SettingUI, CustomUI, None
}

public class GameRoomUIManager : MonoBehaviour
{
    public static GameRoomUIManager instance;

    [SerializeField] private List<GameObject> panelList;

    [SerializeField] private Button useButton;
    [SerializeField] private Sprite originButtonSprite;

    private void Awake()
    {
        instance = this;
    }

    public void SetUseButton(Sprite sprite, UnityAction action)
    {
        useButton.onClick.AddListener(action);
        useButton.image.sprite = sprite;
        useButton.image.color = new Color(1f, 1f, 1f, 1f);
        useButton.interactable = true;
    }

    public void UnsetUseButton()
    {
        useButton.onClick.RemoveAllListeners();
        useButton.image.sprite = originButtonSprite;
        useButton.image.color = new Color(1f, 1f, 1f, 0.5f);
        useButton.interactable = false;
    }

    #region UIOnOffFunction
    private void OpenPanel(EGameRoomPanelType panel)
    {
        panelList[(int)panel].SetActive(true);

    }

    private void ClosePanel(EGameRoomPanelType panel)
    {
        panelList[(int)panel].SetActive(false);
    }

    public void OpenMainUI()
    {
        OpenPanel(EGameRoomPanelType.MainUI);
    }

    public void CloseMainUI()
    {
        ClosePanel(EGameRoomPanelType.MainUI);
    }

    public void OpenSettingUI()
    {
        OpenPanel(EGameRoomPanelType.SettingUI);
        AmongUsPlayer.MyPlayer.SetMovable(false);
    }

    public void CloseSettingUI()
    {
        ClosePanel(EGameRoomPanelType.SettingUI);
        AmongUsPlayer.MyPlayer.SetMovable(true);
    }

    public void OpenCustomUI()
    {
        OpenPanel(EGameRoomPanelType.CustomUI);
        AmongUsPlayer.MyPlayer.SetMovable(false);
    }

    public void CloseCustomUI()
    {
        ClosePanel(EGameRoomPanelType.CustomUI);
        AmongUsPlayer.MyPlayer.SetMovable(true);
    }

    #endregion
}
