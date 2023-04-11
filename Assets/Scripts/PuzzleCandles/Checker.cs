using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour, IClickable
{
    [SerializeField] private List<Image> createdImages;

    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        
    }

    public void OnClick()
    {
        foreach (Image image in createdImages)
        {
            if (image.sprite == null)
            {
                image.sprite = spriteRenderer.sprite;
                return;
            }
        }
    }

    public void SetSprite(Sprite sprite)
    {
        sprites.Add(sprite);
        SpriteMerge();
    }

    public void RemoveSprite(Sprite sprite)
    {
        sprites.Remove(sprite);
        SpriteMerge();
    }

    private void SpriteMerge()
    {
        //Resources.UnloadUnusedAssets();
        Texture2D newTexture = new Texture2D(100, 100); // Важно учитывать размер изображения

        for (int x = 0; x < newTexture.width; x++)
        {
            for (int y = 0; y < newTexture.height; y++)
            {
                newTexture.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        if (sprites.Count > 0)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                for (int x = 0; x < sprites[i].texture.width; x++)
                {
                    for (int y = 0; y < sprites[i].texture.height; y++)
                    {
                        Color color = sprites[i].texture.GetPixel(x, y).a == 0 ? newTexture.GetPixel(x, y) : sprites[i].texture.GetPixel(x, y);
                        newTexture.SetPixel(x, y, color);
                    }
                }
            }
        }

        newTexture.Apply();
        Sprite finalSprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
        finalSprite.name = SetNameSprite();
        spriteRenderer.sprite = finalSprite;
    }

    private string SetNameSprite()
    {
        string name = null;

        foreach (Sprite sprite in sprites)
        {
            name = (name == null) ? name = sprite.name : name += " + " + sprite.name;
        }

        return name;
    }
}
