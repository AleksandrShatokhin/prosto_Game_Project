using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithNumber : PickableItem
{
    [SerializeField] private ButtonColor buttonColor;
    public ButtonColor GetButtonColor() => buttonColor;

    [SerializeField] private Sprite spriteToBox;
    public Sprite GetSpriteToBox() => spriteToBox;

    public override void OnClick()
    {
        base.OnClick();
    }

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