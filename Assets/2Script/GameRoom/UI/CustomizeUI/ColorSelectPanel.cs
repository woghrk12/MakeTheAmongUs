using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectPanel : MonoBehaviour
{
    [SerializeField] private Image characterPreview;

    private void Awake()
    {
        var inst = Instantiate(characterPreview.material);
        characterPreview.material = inst;
    }

    private void OnEnable()
    {
        SetPreviewImageColor((int)AmongUsPlayer.MyPlayer.playerColor);
    }

    private void SetPreviewImageColor(int color)
    {
        characterPreview.material.SetColor("_PlayerColor", PlayerColor.GetColor((EPlayerColor)color));
    }
}
