using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameRoomManager : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("Among Us Player", Vector3.zero, Quaternion.identity);
    }
}
