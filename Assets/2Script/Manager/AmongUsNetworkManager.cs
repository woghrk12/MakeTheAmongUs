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

    public List<RoomInfo> roomList { get; private set; }

    private void Awake()
    {
        var objs = FindObjectsOfType<AmongUsNetworkManager>();

        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Screen.SetResolution(1024, 768, false);

        roomList = new List<RoomInfo>();
    }


    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        foreach (var room in _roomList)
        {
            if (room.RemovedFromList) 
            {
                RemoveRoom(roomList, room);
                continue;
            }

            if (FindRooom(roomList, room) == -1)
            {
                AddRoom(roomList, room);
                continue;
            }

            ModifyRoom(roomList, room);
        }
    }

    private int FindRooom(List<RoomInfo> roomInfos, RoomInfo targetRoom)
    {
        return roomInfos.FindIndex(x => x.Equals(targetRoom));
    }

    private void AddRoom(List<RoomInfo> roomInfos, RoomInfo newRoom)
    {
        roomInfos.Add(newRoom);
    }

    private void RemoveRoom(List<RoomInfo> roomInfos, RoomInfo targetRoom)
    {
        roomInfos.Remove(roomInfos.Find(x => x.Equals(targetRoom)));
    }

    private void ModifyRoom(List<RoomInfo> roomInfos, RoomInfo newRoom)
    {
        var index = roomInfos.FindIndex(x => x.Equals(newRoom));
        roomInfos[index] = newRoom;
    }

    public void CreateRoom(RoomOptions roomOptions)
    {
        SceneManager.sceneLoaded += LoadEnd;
        StartCoroutine(Load());
        PhotonNetwork.CreateRoom(PlayerSetting.nickname, roomOptions);
    }

    public void JoinRoom(string roomName)
    {
        SceneManager.sceneLoaded += LoadEnd;
        StartCoroutine(Load());
        PhotonNetwork.JoinRoom(roomName);
    }

    private IEnumerator Load()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("GameRoom");
        
        while (!op.isDone || !PhotonNetwork.InRoom)
        {
            yield return null;
        }
    }

    private void LoadEnd(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.sceneLoaded -= LoadEnd;
    }
}
