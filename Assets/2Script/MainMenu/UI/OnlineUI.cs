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
            MainMenuUIManager.instance.ChangeUI(EMainMenuPanelType.CreateRoomUI, EMainMenuPanelType.OnlineUI);
        }
    }
    private void OpenJoinRoomUI()
    {
        if (CheckNickname(nicknameInput.text))
        {
            MainMenuUIManager.instance.ChangeUI(EMainMenuPanelType.JoinRoomUI, EMainMenuPanelType.OnlineUI);
        }
    }

    private void CloseOnlineUI()
    {
        AmongUsNetworkManager.Instance.Disconnect();

        MainMenuUIManager.instance.ChangeUI(EMainMenuPanelType.MainUI, EMainMenuPanelType.OnlineUI);
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
