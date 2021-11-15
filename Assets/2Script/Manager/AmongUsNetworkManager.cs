using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class AmongUsNetworkManager : MonoBehaviourPunCallbacks
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

    [SerializeField] private UnityEngine.UI.Text text;
    private string statusText;

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

    private void Update()
    {
        statusText = PhotonNetwork.NetworkClientState.ToString();
        text.text = $"Status : {statusText}";
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public void CreateRoom(RoomOptions roomOptions)
    {
        PhotonNetwork.CreateRoom(PlayerSetting.nickname, roomOptions);
    }

    public override void OnJoinedRoom()
    { 
        SceneManager.LoadScene("GameRoom");
    }
}
