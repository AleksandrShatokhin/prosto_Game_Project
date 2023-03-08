using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//

public abstract class PickableItem : MonoBehaviour, IClickable
{
    
    [SerializeField] private PlayerInventory playerInventory;
    public void OnClick()
    {
        playerInventory.AddItemToInventory(this);
    }

    public void OnItemRemove()
    {
        playerInventory.RemoveItemFromInventory(this);
    }

    public abstract void OnItemCombineAttempt();
}
