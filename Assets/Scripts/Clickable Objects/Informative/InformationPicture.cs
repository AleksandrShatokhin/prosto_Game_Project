using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPicture : MonoBehaviour, IClickable
{
    [SerializeField] private List<string> informativeText;
    [SerializeField] private int indicator;

    private void Start()
    {
        indicator = 0;
    }

    public void OnClick()
    {
        GameController.GetInstance().DisplayMessageOnScreen(informativeText[indicator]);
        indicator += 1;

        if (indicator == informativeText.Count)
        {
            indicator = 0;
        }
    }
}
