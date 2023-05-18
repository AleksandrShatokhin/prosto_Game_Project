using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxButtonSpriteSwitcher : MonoBehaviour
{
    [SerializeField] private BoxCheckerManager checkComponent;
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private int indicator;

    private bool isActiveButtonClick;

    private void Start()
    {
        isActiveButtonClick = true;
        SetFirstSprite();
    }

    public void ClickButton()
    {
        if (isActiveButtonClick == false)
        {
            return;
        }

        UIAudioManager.instance._uiAudioSource.volume = 0.4f;
        UIAudioManager.instance.PlayClickAudio();

        checkComponent.StopCoroutineCheck();

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

    public void ActiveButtonClick_Off() => isActiveButtonClick = false;
}
