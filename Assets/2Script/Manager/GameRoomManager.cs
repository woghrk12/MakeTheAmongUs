using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameRoomManager : MonoBehaviourPunCallbacks
{
    public static GameRoomManager instance;

    public PhotonView PV;

    [SerializeField] private ColorSelectPanel colorSelectPanel;

    public bool[] isExistColor { private set; get; }

    private void Awake()
    {
        instance = this;

        isExistColor = new bool[(int)EPlayerColor.End];
    }

    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        var player = PhotonNetwork.Instantiate("Among Us Player", Vector3.zero, Quaternion.identity).GetComponent<AmongUsPlayer>();
        player.PV.RPC("SetPlayer", RpcTarget.AllBuffered);
    }

    public void AddExistColor(int color)
    {
        isExistColor[color] = true;
        if (colorSelectPanel.gameObject.activeSelf)
            colorSelectPanel.PV.RPC("UpdateColorButton", RpcTarget.All, color);
    }

    public void RemoveExistColor(int color)
    {
        isExistColor[color] = false;
        if (colorSelectPanel.gameObject.activeSelf)
            colorSelectPanel.PV.RPC("UpdateColorButton", RpcTarget.All, color);
    }

    public int GetEnableColor()
    {
        int idx;

        for (idx = 0; idx < isExistColor.Length; idx++)
        {
            if (!isExistColor[idx])
                break;
        }

        return idx;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PV.RPC("RemovePlayer", RpcTarget.AllBuffered, otherPlayer.ActorNumber);
    }

    [PunRPC]
    private void RemovePlayer(int actorNum)
    {
        var players = FindObjectsOfType<AmongUsPlayer>();

        foreach (var player in players)
        {
            if (player.actorNum == actorNum)
            {
                RemoveExistColor((int)player.playerColor);
                break;
            }
        }
    }
}
