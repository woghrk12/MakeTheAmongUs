using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ColorSelectPanel : MonoBehaviour
{
    [SerializeField] private Image characterPreview;
    [SerializeField] private List<Button> colorSelectButtons;

    private PhotonView PV;

    private void Awake()
    {
        var inst = Instantiate(characterPreview.material);
        characterPreview.material = inst;

        PV = GetComponent<PhotonView>();
    }

    private void OnEnable()
    {
        UpdateAllColorButton();
        SetPreviewImageColor((int)AmongUsPlayer.MyPlayer.playerColor);
    }

    private void SetPreviewImageColor(int color)
    {
        characterPreview.material.SetColor("_PlayerColor", PlayerColor.GetColor((EPlayerColor)color));
    }

    public void OnClickColorButton(int color)
    {
        var player = AmongUsPlayer.MyPlayer;
        int oldColor = (int)player.playerColor;

        player.PV.RPC("SetPlayerColor", RpcTarget.AllBuffered, color);

        PV.RPC("UpdateColorButton", RpcTarget.AllBuffered, oldColor);
        PV.RPC("UpdateColorButton", RpcTarget.AllBuffered, color);

        SetPreviewImageColor(color);
    }

    private void UpdateAllColorButton()
    {
        for (int idx = 0; idx < colorSelectButtons.Count; idx++)
        {
            colorSelectButtons[idx].interactable = !GameRoomManager.instance.isExistColor[idx];
        }
    }

    [PunRPC]
    private void UpdateColorButton(int color)
    {
        colorSelectButtons[color].interactable = !GameRoomManager.instance.isExistColor[color];
    }
}
