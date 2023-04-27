using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpriteChenger : MonoBehaviour
{
    [SerializeField] private Sprite chengedSprite;
    private Sprite defaultSprite;

    private void Start()
    {
        defaultSprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseEnter()
    {
        this.GetComponent<SpriteRenderer>().sprite = chengedSprite;
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    private void OnDisable()
    {
        this.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }
}
