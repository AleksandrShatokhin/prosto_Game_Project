using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cup : MonoBehaviour, IClickable
{
    [SerializeField] public float waterLevel = 0;
    [SerializeField] private float maxCapacity;
    [SerializeField] private CupsPuzzle cupsPuzzle;
    [SerializeField] private Image waterImage;


    private void Awake()
    {
        UpdateWaterLevelImage();
    }
    public void OnClick()
    {
        if (cupsPuzzle.ChosenCup == null)
        {
            cupsPuzzle.ChosenCup = this;
            HighlightCup();
        }
        else
        {
            cupsPuzzle.ChosenCup.DehighlightCup();
            PourWater(cupsPuzzle.ChosenCup);
            cupsPuzzle.ChosenCup = null;
        }
    }

    private void HighlightCup()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.2589358f, 1f, 0.03301889f, 0.2470588f);
    }

    public void DehighlightCup()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2470588f);
    }

    private void PourWater(Cup cupToPourFrom)
    {
        if (cupToPourFrom != this)
        {
            if (cupToPourFrom.waterLevel + waterLevel > maxCapacity)
            {
                float waterDelta = (cupToPourFrom.waterLevel + waterLevel) - maxCapacity;
                waterLevel = maxCapacity;
                cupToPourFrom.waterLevel = waterDelta;
            }
            else
            {
                waterLevel = waterLevel + cupToPourFrom.waterLevel;
                cupToPourFrom.waterLevel = 0;
            }
            cupsPuzzle.CheckForAnswer();
            UpdateWaterLevelImage();
            cupToPourFrom.UpdateWaterLevelImage();
        }
    }

    public void UpdateWaterLevelImage()
    {
        waterImage.fillAmount = waterLevel / maxCapacity;
    }
}
