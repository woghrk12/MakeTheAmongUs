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
        if (PhotonNetwork.InLobby)
        {
            statusText = PhotonNetwork.NetworkClientState.ToString();
            text.text = $"Status : {statusText}";
        }
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public void CreateRoom(RoomOptions roomOptions)
    {
        PhotonNetwork.CreateRoom(PlayerSetting.nickname, roomOptions);
        SceneManager.sceneLoaded += LoadEnd;
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("GameRoom");
        
        while (!op.isDone || !PhotonNetwork.InRoom)
        {
            yield return null;
        }

        Debug.Log("InGameRoom");
        SpawnCharacter();
    }

    private void LoadEnd(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("LoadEnd");
        SceneManager.sceneLoaded -= LoadEnd;
    }

    private void SpawnCharacter()
    {
        PhotonNetwork.Instantiate("Room Player", Vector3.zero, Quaternion.identity);
    }
}
