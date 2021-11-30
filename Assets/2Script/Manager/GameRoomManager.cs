using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameRoomManager : MonoBehaviourPunCallbacks
{
    public static GameRoomManager instance;

    public PhotonView PV;

    public bool[] isExistColor;

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
        var player = PhotonNetwork.Instantiate("Among Us Player", Vector3.zero, Quaternion.identity);
    }
    
    [PunRPC]
    public void AddExistColor(int color)
    {
        isExistColor[color] = true;
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
}
