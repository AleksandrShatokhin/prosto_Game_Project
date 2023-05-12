using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box1ColorMarkers : MonoBehaviour
{
    [SerializeField] private int indicator;
    [SerializeField] private List<Image> imageMerkers;
    [SerializeField] private Color defaulColor;
    [SerializeField] private Sprite defaultSprite;
    private bool isCanChangeColor;
    public void IsCanChangeColor_On() => isCanChangeColor = true;

    private void Start()
    {
        isCanChangeColor = false;
    }

    public void SetNewColorToMarker(Sprite marker)
    {
        if (isCanChangeColor == false)
        {
            return;
        }

        imageMerkers[indicator].sprite = marker;
        indicator += 1;

        if (indicator == imageMerkers.Count)
        {
            MarkersClear();
        }
    }

    public void MarkersClear()
    {
        indicator = 0;

        foreach (Image image in imageMerkers)
        {
            image.sprite = defaultSprite;
        }
    }
}
