using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterColor : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    public PhotonView PV;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        var inst = Instantiate(spriteRender.material);
        spriteRender.material = inst;

        PV = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void SetCharacterColorRPC(int color)
    {
        spriteRender.material.SetColor("_PlayerColor", PlayerColor.GetColor((EPlayerColor)color));
    }
}
