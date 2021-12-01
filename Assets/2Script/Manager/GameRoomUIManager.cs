using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum EGameRoomPanelType
{ 
    MainUI, SettingUI, CustomUI, None
}

public class GameRoomUIManager : MonoBehaviour
{
    public static GameRoomUIManager instance;

    [SerializeField] private List<GameObject> panelList;

    [SerializeField] private Button useButton;
    [SerializeField] private Sprite originButtonSprite;

    private void Awake()
    {
        instance = this;
    }

    public void OpenPanel(EGameRoomPanelType panel)
    {
        panelList[(int)panel].SetActive(true);
    }

    public void ClosePanel(EGameRoomPanelType panel)
    {
        panelList[(int)panel].SetActive(false);
    }

    public void SetUseButton(Sprite sprite, UnityAction action)
    {
        useButton.onClick.AddListener(action);
        useButton.image.sprite = sprite;
        useButton.image.color = new Color(1f, 1f, 1f, 1f);
        useButton.interactable = true;
    }

    public void UnsetUseButton()
    {
        useButton.onClick.RemoveAllListeners();
        useButton.image.sprite = originButtonSprite;
        useButton.image.color = new Color(1f, 1f, 1f, 0.5f);
        useButton.interactable = false;
    }
}
