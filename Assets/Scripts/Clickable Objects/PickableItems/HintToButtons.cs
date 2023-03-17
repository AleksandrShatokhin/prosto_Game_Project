using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintToButtons : PickableItem
{
    [SerializeField] GameObject hint;

    public override void OnClick()
    {
        OpenHintToScreen();
    }

    private void OpenHintToScreen()
    {
        hint.SetActive(true);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
