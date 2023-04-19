using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxButtonSpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Box_2_CheckComponent checkComponent;
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private int indicator;

    private void Start()
    {
        SetFirstSprite();
    }

    public void ClickButton()
    {
        //checkComponent.StopCoroutineCheck();

        if (indicator == spriteList.Count - 1)
        {
            SetFirstSprite();
        }
        else
        {
            SetNewSprite();
        }

        checkComponent.StartCoroutineCheck();
    }

    private void SetFirstSprite()
    {
        indicator = 0;
        this.GetComponent<Image>().sprite = spriteList[indicator];
    }

    private void SetNewSprite()
    {
        indicator += 1;
        this.GetComponent<Image>().sprite = spriteList[indicator];
    }
}
