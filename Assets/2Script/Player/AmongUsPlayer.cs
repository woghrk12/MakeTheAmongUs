using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class AmongUsPlayer : MonoBehaviour
{
    public static AmongUsPlayer MyPlayer;

    public int actorNum { private set; get; }

    public EPlayerColor playerColor;

    public PhotonView PV;

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
        PV.RPC("SetPlayerColor", RpcTarget.AllBuffered, (int)playerColor);
    }

    [PunRPC]
    public void SetPlayer()
    {
        actorNum = PV.Owner.ActorNumber;
        playerColor = (EPlayerColor)GameRoomManager.instance.GetEnableColor();
    }
    
    public void SetMovable(bool value)
    {
        if (playerCharacter != null)
            playerCharacter.GetComponent<CharacterMove>().IsMovable = value;
    }

    [PunRPC]
    public void SetPlayerColor(int color)
    {
        if (playerColor != EPlayerColor.End)
            GameRoomManager.instance.RemoveExistColor((int)playerColor);
        
        playerColor = (EPlayerColor)color;

        if (PV.IsMine)
            playerCharacter.GetComponent<CharacterColor>().PV.RPC(
                "SetCharacterColorRPC", 
                RpcTarget.AllBuffered, 
                (int)playerColor
                );

        GameRoomManager.instance.AddExistColor((int)color);
    }
}
