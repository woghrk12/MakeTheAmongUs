using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoomUI : MonoBehaviour
{
    [SerializeField] private GameObject onlineUI;

    public void OnClickBackButton() => CloseJoinRoomUI();

    private void CloseJoinRoomUI()
    {
        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
