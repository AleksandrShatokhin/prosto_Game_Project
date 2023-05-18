using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBox2 : MonoBehaviour
{
    [SerializeField] private BoxCheckerManager checkComponent;
    [SerializeField] private Image spriteHandler;

    public void OnValueChange()
    {
        checkComponent.StopCoroutineCheck();
        checkComponent.StartCoroutineCheck();
        UIAudioManager.instance.PlaySliderClickAudio(0.6f);
    }

    public void SetWinSpriteToHandler(Sprite sprite)
    {
        spriteHandler.sprite = sprite;
    }
}
