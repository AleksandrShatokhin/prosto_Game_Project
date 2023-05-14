using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box1ColorMarkers : MonoBehaviour
{
    [SerializeField] private int indicator;
    [SerializeField] private List<Image> imageMerkers;
    [SerializeField] private Sprite defaultSprite, winnerSprite;
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
            SwitchSprite(this.GetComponent<Box_1>().GetIsWin());
        }
    }

    public void SwitchSprite(bool isWin)
    {
        if (isWin == true)
        {
            SetWinnerSprite();
        }
        else
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

    public void SetWinnerSprite()
    {
        indicator = 0;

        foreach (Image image in imageMerkers)
        {
            image.sprite = winnerSprite;
        }
    }
}
