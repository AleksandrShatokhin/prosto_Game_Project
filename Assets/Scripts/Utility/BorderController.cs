using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    [SerializeField] private GameObject backgroundImage;

    private void Start()
    {
        var spriteRender = backgroundImage.GetComponent<SpriteRenderer>();
        CreateSize(spriteRender);
    }

    private void CreateSize(SpriteRenderer sr_Background)
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;
        Sprite spriteBackground = sr_Background.sprite;
        float spriteBackgroundWidth = spriteBackground.textureRect.width / spriteBackground.pixelsPerUnit;
        float spriteBackgroundHeight = spriteBackground.textureRect.height / spriteBackground.pixelsPerUnit;

        sr_Background.transform.localScale = new Vector2(width / spriteBackgroundWidth, height / spriteBackgroundHeight);
    }
}
