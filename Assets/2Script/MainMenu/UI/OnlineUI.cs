using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.InputField nicknameInput;

    public void OnClickBackButton() => CloseOnlineUI();
    public void OnClickCreateRoomButton() => OpenCreateRoomUI();
    public void OnClickJoinRoomButton() => OpenJoinRoomUI();

    private void OpenCreateRoomUI()
    {
        if (CheckNickname(nicknameInput.text))
        {
            MainMenuUIManager.instance.OpenPanel(EMainMenuPanelType.CreateRoomUI);
            MainMenuUIManager.instance.ClosePanel(EMainMenuPanelType.OnlineUI);
        }
    }
    private void OpenJoinRoomUI()
    {
        if (CheckNickname(nicknameInput.text))
        {
            MainMenuUIManager.instance.OpenPanel(EMainMenuPanelType.JoinRoomUI);
            MainMenuUIManager.instance.ClosePanel(EMainMenuPanelType.OnlineUI);
        }
    }

    private void CloseOnlineUI()
    {
        AmongUsNetworkManager.Instance.Disconnect();

        MainMenuUIManager.instance.OpenPanel(EMainMenuPanelType.MainUI);
        MainMenuUIManager.instance.ClosePanel(EMainMenuPanelType.OnlineUI);
    }

    private void SetNickname(string value)
    {
        PlayerSetting.nickname = value;
        nicknameInput.text = "";
    }

    private bool CheckNickname(string value)
    {
        if (value.TrimStart() == "")
        {
            nicknameInput.GetComponent<Animator>().SetTrigger("On");
            return false;
        }

        SetNickname(value);
        return true;
    }
}
