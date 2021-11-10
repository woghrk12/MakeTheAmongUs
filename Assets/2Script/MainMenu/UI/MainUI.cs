using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;

    public void OnClickSettingButton()
    {
        ActiveSettingUI();
    }

    private void ActiveSettingUI()
    {
        settingUI.SetActive(true);
    }
}
