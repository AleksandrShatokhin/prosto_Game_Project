using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinegar : PickableItem
{
    public override void OnClick()
    {
        base.OnClick();
        this.gameObject.SetActive(false);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
