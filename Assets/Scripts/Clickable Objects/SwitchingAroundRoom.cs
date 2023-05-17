using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingAroundRoom : MonoBehaviour, IClickable
{
    [SerializeField] GameObject opanableWindow, roomWindow;

    public void OnClick()
    {
        OpenNewWindow();
        UIAudioManager.instance._uiAudioSource.volume = 0.4f;
        UIAudioManager.instance.PlayClickSoftAudio(0.4f);
    }

    private void OpenNewWindow() => GameController.GetInstance().SwitchWindow(opanableWindow, roomWindow);
}
