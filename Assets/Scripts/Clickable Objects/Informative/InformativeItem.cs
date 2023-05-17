using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformativeItem : MonoBehaviour, IClickable
{
    [SerializeField] private string informativeText;

    public void OnClick()
    {
        GameController.GetInstance().DisplayMessageOnScreen(informativeText);
        UIAudioManager.instance.PlayClickSoftAudio(0.4f);
    }
}