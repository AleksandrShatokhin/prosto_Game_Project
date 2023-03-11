using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithNumber : PickableItem
{
    [SerializeField] int value;
    public int GetValue() => value;

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
