using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingAroundRoom : PickableItem
{
    [SerializeField] GameObject opanableWindow, roomWindow;

    public override void OnClick()
    {
        OpenNewWindow();
    }

    private void OpenNewWindow()
    {
        GameController.GetInstance().SwitchWindow(opanableWindow, roomWindow);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
