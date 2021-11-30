using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeLaptop : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button useButton;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var inst = Instantiate(spriteRenderer.material);
        spriteRenderer.material = inst;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterColor>();

        if (character != null && character.PV.IsMine)
        {
            spriteRenderer.material.SetFloat("_Highlighted", 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterColor>();

        if (character != null && character.PV.IsMine)
        {
            spriteRenderer.material.SetFloat("_Highlighted", 0f);
        }
    }
}
