using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class AmongUsPlayer : MonoBehaviour
{
    public static AmongUsPlayer MyPlayer;

    public EPlayerColor playerColor;

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
            playerColor = (EPlayerColor)GameRoomManager.instance.GetEnableColor();
            CreateRoomPlayer();
        }
    }

    private void CreateRoomPlayer()
    {
        var spawnPositions = FindObjectOfType<SpawnPositions>();
        playerCharacter = PhotonNetwork.Instantiate("Room Player", spawnPositions.GetSpawnPosition(), Quaternion.identity);
        playerCharacter.GetComponent<CharacterColor>().PV.RPC("SetCharacterColorRPC", RpcTarget.AllBuffered, (int)playerColor);
        GameRoomManager.instance.PV.RPC("AddExistColor", RpcTarget.AllBuffered, (int)playerColor);
    }

    public void SetMovable(bool value)
    {
        playerCharacter.GetComponent<CharacterMove>().IsMovable = value;
    }

    [PunRPC]
    public void SetPlayerColor(int color)
    {
        playerCharacter.GetComponent<CharacterColor>().PV.RPC("SetCharacterColorRPC", RpcTarget.AllBuffered, color);
    }
}
