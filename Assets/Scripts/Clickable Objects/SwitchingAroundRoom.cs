using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingAroundRoom : MonoBehaviour, IClickable
{
    [SerializeField] GameObject opanableWindow, roomWindow;

    public void OnClick()
    {
        OpenNewWindow();
    }

    private void OpenNewWindow() => GameController.GetInstance().SwitchWindow(opanableWindow, roomWindow);
}
