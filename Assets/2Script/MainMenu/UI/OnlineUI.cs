using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineUI : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;

    public void OnClickBackButton() => CloseOnlineUI();

    private void CloseOnlineUI()
    {
        mainUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
