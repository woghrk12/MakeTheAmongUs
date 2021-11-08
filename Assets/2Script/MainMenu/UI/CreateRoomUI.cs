using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private GameObject onlineUI;

    public void OnClickCancelButton() => CloseCreateRoomUI();

    private void CloseCreateRoomUI()
    {
        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
