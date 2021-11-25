using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameRoomManager : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        var spawnPositions = FindObjectOfType<SpawnPositions>();
        PhotonNetwork.Instantiate("Room Player", spawnPositions.GetSpawnPosition(), Quaternion.identity);
    }
}
