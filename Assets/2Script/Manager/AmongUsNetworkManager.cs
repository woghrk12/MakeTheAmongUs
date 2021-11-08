using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AmongUsNetworkManager : MonoBehaviour
{
    private readonly string gameVersion = "1";

    private static AmongUsNetworkManager instance;
    public static AmongUsNetworkManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<AmongUsNetworkManager>();

                if (obj != null) instance = obj;
                else 
                {
                    var newObj = new GameObject().AddComponent<AmongUsNetworkManager>();
                    instance = newObj;
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<AmongUsNetworkManager>();

        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();
}
