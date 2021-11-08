using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private GameObject onlineUI;

    [SerializeField] private List<Button> maxPlayerButtons;

    private int maxPlayerCount = 10;

    public void OnClickCancelButton() => CloseCreateRoomUI();
    public void OnClickMaxPlayerButton(int value) => UpdateMaxPlayerCount(value);

    private void CloseCreateRoomUI()
    {
        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }

    private void UpdateMaxPlayerCount(int value)
    {
        maxPlayerCount = value;

        for (int i = 0; i < maxPlayerButtons.Count; i++)
        {
            SetButtonAlpha(maxPlayerButtons[i], (i == value - 4) ? 1f : 0f);
        }
    }

    private void SetButtonAlpha(Button button, float alpha)
    {
        button.image.color = new Color(1f, 1f, 1f, alpha);
    }
}
