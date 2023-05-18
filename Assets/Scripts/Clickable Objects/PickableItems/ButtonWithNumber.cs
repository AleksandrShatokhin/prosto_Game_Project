using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithNumber : PickableItem
{
    [SerializeField] private ButtonColor buttonColor;
    public ButtonColor GetButtonColor() => buttonColor;

    [SerializeField] private Sprite spriteToBox;
    public Sprite GetSpriteToBox() => spriteToBox;

    [SerializeField] private Sprite spriteToInventory;
    public override Sprite GetSpriteToInventory() => spriteToInventory;

    public override void OnClick()
    {
        base.OnClick();
        UIAudioManager.instance.PlayPickupAudio(0.5f);
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