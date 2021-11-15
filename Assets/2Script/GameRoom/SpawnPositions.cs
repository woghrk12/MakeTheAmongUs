using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SpawnPositions : MonoBehaviour
{
    [SerializeField] private Transform[] positions;

    public Vector3 GetSpawnPosition()
    {
        var hash = PhotonNetwork.CurrentRoom.CustomProperties;
        var index = (int)hash["SpawnIndex"];

        if (index >= positions.Length) index = 0;

        hash["SpawnIndex"] = index + 1;
        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);

        return positions[index].position;
    }
}
