using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithNumber : PickableItem
{
    [SerializeField] private ButtonColor buttonColor;
    public ButtonColor GetButtonColor() => buttonColor;

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}

public enum ButtonColor
{
    Green,
    Red,
    Purple
}