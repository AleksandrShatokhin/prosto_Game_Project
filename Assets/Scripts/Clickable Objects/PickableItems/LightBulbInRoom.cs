using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbInRoom : PickableItem
{
    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
