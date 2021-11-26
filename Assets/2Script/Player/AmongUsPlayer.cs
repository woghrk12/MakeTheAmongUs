using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class AmongUsPlayer : MonoBehaviour
{
    public static AmongUsPlayer MyPlayer;
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PV.IsMine) MyPlayer = this;
    }
  
}
