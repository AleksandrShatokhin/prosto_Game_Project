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
        if (playerInventory.AddItemToInventory(this, GetSpriteToInventory()) == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnItemRemove()
    {
        playerInventory.RemoveItemFromInventory(this);
    }

    public virtual Sprite GetSpriteToInventory() { return null; }

    public abstract void OnItemCombineAttempt();
}
