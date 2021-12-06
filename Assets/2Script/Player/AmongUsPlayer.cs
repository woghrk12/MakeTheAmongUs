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
            playerColor = (EPlayerColor)GameRoomManager.instance.GetEnableColor();
            CreateRoomPlayer();
            PV.RPC("SetPlayer", RpcTarget.AllBuffered);
        }
    }

    private void CreateRoomPlayer()
    {
        var spawnPositions = FindObjectOfType<SpawnPositions>();
        playerCharacter = PhotonNetwork.Instantiate("Room Player", spawnPositions.GetSpawnPosition(), Quaternion.identity);
        playerCharacter.GetComponent<CharacterColor>().PV.RPC("SetCharacterColorRPC", RpcTarget.AllBuffered, (int)playerColor);
        GameRoomManager.instance.PV.RPC("AddExistColor", RpcTarget.AllBuffered, (int)playerColor);
    }

    [PunRPC]
    public void SetPlayer()
    {
        actorNum = PV.Owner.ActorNumber;
    }
    
    public void SetMovable(bool value)
    {
        if (playerCharacter != null)
            playerCharacter.GetComponent<CharacterMove>().IsMovable = value;
    }

    [PunRPC]
    public void SetPlayerColor(int color)
    {
        GameRoomManager.instance.PV.RPC("RemoveExistColor", RpcTarget.AllBuffered, (int)playerColor);
        
        playerColor = (EPlayerColor)color;

        if (PV.IsMine)
            playerCharacter.GetComponent<CharacterColor>().PV.RPC(
                "SetCharacterColorRPC", 
                RpcTarget.AllBuffered, 
                (int)playerColor
                );
       
        GameRoomManager.instance.PV.RPC("AddExistColor", RpcTarget.AllBuffered, (int)playerColor);
    }
}
