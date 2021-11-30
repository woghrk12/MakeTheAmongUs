using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] private Color outlineColor;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var inst = Instantiate(spriteRenderer.material);
        spriteRenderer.material = inst;
        spriteRenderer.material.SetColor("_OutlineColor", outlineColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterColor>();

        if (character != null && character.PV.IsMine)
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterColor>();

        if (character != null && character.PV.IsMine)
        {
            spriteRenderer.enabled = false;
        }
    }
}
