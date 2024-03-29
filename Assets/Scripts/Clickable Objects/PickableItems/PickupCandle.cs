using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCandle : PickableItem
{
    [SerializeField] private Sprite spriteCandle;
    public override Sprite GetSpriteToInventory() => spriteCandle;

    public override void OnClick()
    {
        base.OnClick();
        UIAudioManager.instance.PlayPickupAudio(0.7f);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}