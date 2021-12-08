using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButton : MonoBehaviour
{
    [SerializeField] private Image xImage;

    private bool isInteractable 
    {
        set 
        {
            gameObject.GetComponent<Button>().interactable = value;
        }
    }

    public void SetInteractable(bool value)
    {
        isInteractable = value;
        xImage.gameObject.SetActive(!value);
    }
}
