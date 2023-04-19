using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//

public abstract class PickableItem : MonoBehaviour, IClickable
{
    
    [SerializeField] protected PlayerInventory playerInventory;
    public virtual void OnClick()
    {
        playerInventory.AddItemToInventory(this, GetSpriteToInventory());
    }

    public void OnItemRemove()
    {
        playerInventory.RemoveItemFromInventory(this);
    }

    public virtual Sprite GetSpriteToInventory() { return null; }

    public abstract void OnItemCombineAttempt();
}
