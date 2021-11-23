using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private Image mapImage;
    [SerializeField] private Text roomNameText;
    [SerializeField] private Text imposterCountText;
    [SerializeField] private Image imposterImage;
    [SerializeField] private Text playerCountText;
    [SerializeField] private Image playerImage;
    [SerializeField] private Button roomButton;

    private void Awake()
    {
        var instImposter = Instantiate(imposterImage.material);
        imposterImage.material = instImposter;
        imposterImage.material.SetColor("_PlayerColor", Color.red);

        var instPlayer = Instantiate(playerImage.material);
        playerImage.material = instPlayer;
        playerImage.material.SetColor("_PlayerColor", Color.white);
    }

    public void SetItem(
            Image _mapImage,
            string _roomName,
            int _imposterCount,
            int _maxPlayerCount,
            int _currentPlayerCount
        )
    {
        mapImage = _mapImage;
        roomNameText.text = _roomName;
        imposterCountText.text = _imposterCount.ToString();
        playerCountText.text = $"{_currentPlayerCount.ToString()} / {_maxPlayerCount.ToString()}";
        roomButton.onClick.AddListener(() => AmongUsNetworkManager.Instance.JoinRoom(_roomName));
    }
}
