using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decanter_Empty : PickableItem
{
    [SerializeField] private Sprite spriteDecanter;
    public override Sprite GetSpriteToInventory() => spriteDecanter;

    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
