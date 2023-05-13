using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decanter_Water : PickableItem
{
    [SerializeField] private Sprite spriteToInventory;
    public override Sprite GetSpriteToInventory() => spriteToInventory;

    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
