using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBack : PickableItem
{
    [SerializeField] private GameObject roomWindow;


    public override void OnClick()
    {
        ComeBackButton();
        UIAudioManager.instance._uiAudioSource.volume = 0.4f;
        UIAudioManager.instance.PlayClickAudio();
    }

    private void ComeBackButton()
    {
        GameObject parentWindow = this.transform.parent.gameObject;

        GameController.GetInstance().SwitchWindow(roomWindow, parentWindow);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
