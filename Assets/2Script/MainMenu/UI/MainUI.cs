using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text onlineButtonText;
    [SerializeField] private UnityEngine.UI.Button onlineButton;

    public void OnEnable()
    {
        ChangeOnlineButtonText(false);
    }

    public void OnClickSettingButton()
    {
        ActiveSettingUI();
    }

    public void OnClickOnlineButton()
    {
        StartCoroutine(ActiveOnlineUI());
    }

    public void OnClickExitButton()
    {
        ExitGame();
    }

    private void ActiveSettingUI()
    {
        MainMenuUIManager.instance.OpenSettingUI();
    }

    private IEnumerator ActiveOnlineUI()
    {
        yield return WaitForConnect();

        MainMenuUIManager.instance.OpenOnlineUI();
        MainMenuUIManager.instance.CloseMainUI();
    }

    private IEnumerator WaitForConnect()
    {
        onlineButton.interactable = false;
        
        AmongUsNetworkManager.Instance.Connect();

        ChangeOnlineButtonText(true);

        while (!PhotonNetwork.IsConnected || !PhotonNetwork.InLobby)
        {
            yield return null;
        }

        onlineButton.interactable = true;
    }

    private void ChangeOnlineButtonText(bool isConnecting)
    {
        onlineButtonText.text = isConnecting ? "Loading.." : "Online";
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
