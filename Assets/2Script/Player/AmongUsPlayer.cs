using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class AmongUsPlayer : MonoBehaviour
{
    public static AmongUsPlayer MyPlayer;
    private PhotonView PV;
    private GameObject playerCharacter;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            MyPlayer = this;
            CreateRoomPlayer();
        }
    }

    private void CreateRoomPlayer()
    {
        var spawnPositions = FindObjectOfType<SpawnPositions>();
        playerCharacter = PhotonNetwork.Instantiate("Room Player", spawnPositions.GetSpawnPosition(), Quaternion.identity);
    }
}
