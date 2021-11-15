using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject onlineUI;
    [SerializeField] private UnityEngine.UI.Text onlineButtonText;

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
        settingUI.SetActive(true);
    }

    private IEnumerator ActiveOnlineUI()
    {
        yield return WaitForConnect();

        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }

    private IEnumerator WaitForConnect()
    {
        AmongUsNetworkManager.Instance.Connect();

        ChangeOnlineButtonText(true);

        while (!PhotonNetwork.IsConnected || !PhotonNetwork.InLobby)
        {
            yield return null;
        }
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
