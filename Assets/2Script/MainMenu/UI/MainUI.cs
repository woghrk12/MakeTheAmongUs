using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject onlineUI;

    public void OnClickSettingButton()
    {
        ActiveSettingUI();
    }

    public void OnClickOnlineButton() => ActiveOnlineUI();


    private void ActiveSettingUI()
    {
        settingUI.SetActive(true);
    }

    private void ActiveOnlineUI()
    {
        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
