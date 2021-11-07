using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    private Vector3 direction;
    private float floatingSpeed;
    private float rotateSpeed;
    public EPlayerColor color { private set; get; }

    private SpriteRenderer spriteRender;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Floating();
    }

    private void Floating()
    {
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0f, 0f, rotateSpeed);
    }

    public void SetFloatingCrew(
            Sprite sprite,
            Vector3 direction,
            float floatingSpeed,
            float rotateSpeed,
            float size,
            EPlayerColor color
        )
    {
        spriteRender.sprite = sprite;
        spriteRender.sortingOrder = (int)Mathf.Lerp(1, 32767, size);
        spriteRender.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));

        this.direction = direction;
        this.floatingSpeed = floatingSpeed;
        this.rotateSpeed = rotateSpeed;
        this.color = color;
        transform.localScale = new Vector3(size, size, 1f);
    }
}
