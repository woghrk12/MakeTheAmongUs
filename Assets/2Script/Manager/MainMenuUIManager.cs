using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager instance;

    [SerializeField] private MainUI mainUI;
    [SerializeField] private SettingUI settingUI;
    [SerializeField] private OnlineUI onlineUI;
    [SerializeField] private CreateRoomUI createRoomUI;
    [SerializeField] private JoinRoomUI joinRoomUI;

    public MainUI MainUI { get { return mainUI; } }
    public SettingUI SettingUI { get { return settingUI; } }
    public OnlineUI OnlineUI { get { return onlineUI; } }
    public CreateRoomUI CreateRoomUI { get { return createRoomUI; } }
    public JoinRoomUI JoinRoomUI { get { return joinRoomUI; } }

    private void Awake()
    {
        instance = this;
    }
}
