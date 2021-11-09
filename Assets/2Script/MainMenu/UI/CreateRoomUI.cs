using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private GameObject onlineUI;

    [SerializeField] private List<Image> crewImages;
    [SerializeField] private List<Button> maxPlayerButtons;
    [SerializeField] private List<Button> imposterButtons;

    private int maxPlayerCount = 10;
    private int minPlayerCount = 4;
    private int imposterCount = 1;

    private void Awake()
    {
        for (int i = 0; i < crewImages.Count; i++)
        {
            var inst = Instantiate(crewImages[i].material);
            crewImages[i].material = inst;
        }

        UpdateCrewImage();
    }

    public void OnClickCancelButton() => CloseCreateRoomUI();
    public void OnClickMaxPlayerButton(int value)
    {
        UpdateMaxPlayerCount(value);
        UpdateCrewImage();
    }
    public void OnClickImposterButton(int value)
    {
        UpdateImposterCount(value);
        UpdateCrewImage();
    }
    public void OnClickConfirmButton() => CreateRoom();

    private void CloseCreateRoomUI()
    {
        onlineUI.SetActive(true);
        gameObject.SetActive(false);
    }

    private void UpdateMaxPlayerCount(int value)
    {
        maxPlayerCount = value;

        for (int i = 0; i < maxPlayerButtons.Count; i++)
        {
            SetButtonAlpha(maxPlayerButtons[i], (i == value - 4) ? 1f : 0f);
        }
    }

    private void UpdateImposterCount(int value)
    {
        imposterCount = value;

        for (int i = 0; i < imposterButtons.Count; i++)
        {
            SetButtonAlpha(imposterButtons[i], (i == value - 1) ? 1f : 0f);
        }

        UpdateMinPlayerCount(imposterCount);
    }

    private void UpdateMinPlayerCount(int value)
    {
        minPlayerCount = value == 1 ? 4 : value == 2 ? 6 : 8;

        if (maxPlayerCount < minPlayerCount) UpdateMaxPlayerCount(minPlayerCount);

        for (int i = 0; i < maxPlayerButtons.Count; i++)
        {
            var text = maxPlayerButtons[i].GetComponentInChildren<Text>();

            var flag = i < minPlayerCount - 4;
            maxPlayerButtons[i].interactable = !flag;
            text.color = flag ? Color.gray : Color.white;
        }
    }
  
    private void UpdateCrewImage()
    {
        List<Image> _crewImages = new List<Image>();
        List<Image> _imposterImage = new List<Image>();

        for (int i = 0; i < crewImages.Count; i++)
        {
            if (i < maxPlayerCount)
            {
                crewImages[i].gameObject.SetActive(true);
                _crewImages.Add(crewImages[i]);
                continue;
            }

            crewImages[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < imposterCount; i++)
        {
            var image = _crewImages[Random.Range(0, _crewImages.Count)];

            _imposterImage.Add(image);
            _crewImages.Remove(image);
        }

        for (int i = 0; i < _imposterImage.Count; i++)
            _imposterImage[i].material.SetColor("_PlayerColor", Color.red);

        for (int i = 0; i < _crewImages.Count; i++)
            _crewImages[i].material.SetColor("_PlayerColor", Color.white);
    }

    private void SetButtonAlpha(Button button, float alpha)
    {
        button.image.color = new Color(1f, 1f, 1f, alpha);
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        AmongUsNetworkManager.Instance.CreateRoom(roomOptions);
    }
}
