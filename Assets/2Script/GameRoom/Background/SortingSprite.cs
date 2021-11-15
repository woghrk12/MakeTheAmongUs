using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SortingSprite : MonoBehaviour
{
    public enum ESortingType
    {
        Static, Update
    }

    [SerializeField] private ESortingType sortingType;

    private SpriteSorter sorter;
    private SpriteRenderer spriteRender;

    void Start()
    {
        sorter = FindObjectOfType<SpriteSorter>();
        spriteRender = GetComponent<SpriteRenderer>();

        spriteRender.sortingOrder = sorter.GetSortingOrder(gameObject);
    }

    void Update()
    {
        if(sortingType == ESortingType.Update)
            spriteRender.sortingOrder = sorter.GetSortingOrder(gameObject);
    }
}
