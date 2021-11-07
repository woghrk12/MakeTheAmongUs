using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button mouseButton;
    [SerializeField] private Button keyboardButton;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SwitchButton(PlayerSetting.controlMode);
    }

    public void OnClickBackground()
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
}
