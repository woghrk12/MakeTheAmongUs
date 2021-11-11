using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;


public class JoinRoomUI : MonoBehaviour
{
    [SerializeField] private GameObject onlineUI;
    [SerializeField] private GameObject roomListPanel;
    [SerializeField] private GameObject roomItemPrefab;

    private void OnEnable()
    {
        StopCoroutine(RoomListItemUpdateCo());
        StartCoroutine(RoomListItemUpdateCo());
    }

    public void OnClickBackButton() => CloseJoinRoomUI();

    private void CloseJoinRoomUI()
    {
        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }

    private IEnumerator RoomListItemUpdateCo()
    {
        while (true)
        {
            RoomListItemUpdate(AmongUsNetworkManager.Instance.roomList);

            yield return new WaitForSeconds(3f);
        }
    }

    private void RoomListItemUpdate(List<RoomInfo> _roomList)
    {
        foreach (var room in _roomList)
        {
            var roomItem = Instantiate(roomItemPrefab, roomListPanel.transform);

            // Set roominfo by customproperties of room
            //roomItem.GetComponent<RoomListItem>().SetItem();
        }
    }
}
