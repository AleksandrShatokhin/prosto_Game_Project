using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject candles;
    [SerializeField] private List<Image> createdImages;

    [SerializeField] private List<Sprite> sprites;

    public void OnClick()
    {
        if (CheckActiveCandles() == true)
        {
            AddInMergerListNewShadowSprite();
            AddMergerSpriteInCreatedImageList();
        }
    }

    private bool CheckActiveCandles()
    {
        bool isCandleEnable = false;

        foreach (Transform candle in candles.transform)
        {
            Candle candleComponent = candle.GetComponent<Candle>();

            if (candleComponent.CurrentCandleStatus == CandleStatus.Enabled)
            {
                isCandleEnable = true;
                continue;
            }
        }

        return isCandleEnable;
    }

    private void AddInMergerListNewShadowSprite()
    {
        foreach (Transform candle in candles.transform)
        {
            Candle candleComponent = candle.GetComponent<Candle>();

            if (candleComponent.CurrentCandleStatus == CandleStatus.Enabled)
            {
                sprites.Add(candleComponent.GetShadowSprite());
                candleComponent.ExtinguishCandle();
            }
        }
    }

    private void AddMergerSpriteInCreatedImageList()
    {
        foreach (Image image in createdImages)
        {
            if (image.sprite == null)
            {
                image.sprite = GetMergeSprite();
                return;
            }
        }
    }

    private Sprite GetMergeSprite()
    {
        Texture2D newTexture = new Texture2D(100, 100); // Need to know the correct image size

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

        sprites.Clear();

        return finalSprite;
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
