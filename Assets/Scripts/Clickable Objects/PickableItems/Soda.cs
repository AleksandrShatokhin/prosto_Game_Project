using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : PickableItem
{
    [SerializeField] private Sprite spriteToInventory;
    public override Sprite GetSpriteToInventory() => spriteToInventory;

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
