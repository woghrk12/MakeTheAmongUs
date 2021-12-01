using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JoinRoomUI : MonoBehaviour
{
    [SerializeField] private GameObject roomListPanel;
    [SerializeField] private GameObject roomItemPrefab;
    [SerializeField] private List<GameObject> roomItems;

    [SerializeField] private List<Sprite> bannerImages;

    private void Awake()
    {
        roomItems = new List<GameObject>();
    }

    private void OnEnable()
    {
        StopCoroutine(RoomListItemUpdateCo());
        StartCoroutine(RoomListItemUpdateCo());
    }

    public void OnClickBackButton() => CloseJoinRoomUI();

    private void CloseJoinRoomUI()
    {
        MainMenuUIManager.instance.OpenPanel(EMainMenuPanelType.OnlineUI);
        MainMenuUIManager.instance.ClosePanel(EMainMenuPanelType.JoinRoomUI);
    }

    private IEnumerator RoomListItemUpdateCo()
    {
        while (PhotonNetwork.InLobby)
        {
            RoomListItemUpdate(AmongUsNetworkManager.Instance.roomList);

            yield return new WaitForSeconds(3f);
        }
    }

    private void RoomListItemUpdate(List<RoomInfo> _roomList)
    {
        ClearPanel();

        if (_roomList.Count == 0) return;

        foreach (var room in _roomList)
        {
            var roomItem = Instantiate(roomItemPrefab, roomListPanel.transform);
            roomItem.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => AmongUsNetworkManager.Instance.JoinRoom(room.Name));
            //roomItem.GetComponent<RoomListItem>().SetItem(bannerImages[0], room.Name,)
            roomItems.Add(roomItem);
            // Set roominfo by customproperties of room
            //roomItem.GetComponent<RoomListItem>().SetItem();
        }
    }

    private void ClearPanel()
    {
        if (roomItems.Count == 0) return;

        int totalRoomItem = roomItems.Count;
        for (int i = 0; i < totalRoomItem; i++)
        {
            var temp = roomItems[0];
            roomItems.Remove(temp);
            Destroy(temp);
        }
    }
}
