using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button mouseButton;
    [SerializeField] private Button keyboardButton;

    [SerializeField] private Toggle fullScreenModeToggle;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SwitchButton(PlayerSetting.controlMode);
        SwitchToggle(Screen.fullScreen);
    }

    public void OnClickBackground()
    {
        CloseSettingUI();
    }

    public virtual void CloseSettingUI()
    {
        StartCoroutine(CloseSettingUICo());
    }

    private IEnumerator CloseSettingUICo()
    {
        animator.SetTrigger("Close");

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }

    public void OnClickControlButton(int value)
    {
        SetControlMode(value);
    }

    private void SetControlMode(int controlType)
    {
        PlayerSetting.controlMode = (EControlMode)controlType;

        SwitchButton(PlayerSetting.controlMode);
    }

    private void SwitchButton(EControlMode controlMode)
    {
        switch (PlayerSetting.controlMode)
        {
            case EControlMode.Mouse:
                mouseButton.image.color = Color.green;
                keyboardButton.image.color = Color.white;
                break;

            case EControlMode.Keyboard:
                mouseButton.image.color = Color.white;
                keyboardButton.image.color = Color.green;
                break;
        }
    }

    public void OnClickFullScreenTrigger(bool value)
    {
        ChangeFullScreen(value);
    }

    private void ChangeFullScreen(bool value)
    {
        if (value) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    private void SwitchToggle(bool fullScreenMode)
    {
        fullScreenModeToggle.isOn = fullScreenMode;
    }
}
