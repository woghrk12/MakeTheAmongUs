using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineUI : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;

    [SerializeField] private UnityEngine.UI.InputField nicknameInput;

    public void OnClickBackButton() => CloseOnlineUI();

    private void CloseOnlineUI()
    {
        mainUI.SetActive(true);
        gameObject.SetActive(false);
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
