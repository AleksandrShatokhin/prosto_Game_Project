using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHammer : PickableItem
{
    [SerializeField] private PickableItem hammer;
    [SerializeField] private PickableItem metalHammer;

    [SerializeField] private Sprite spriteToInventory;
    public override Sprite GetSpriteToInventory() => spriteToInventory;

    public override void OnClick()
    {
        if (SearchHammerElementInInventory() == true)
        {
            playerInventory.AddItemToInventory(hammer);
        }
        else
        {
            base.OnClick();
        }

        this.gameObject.SetActive(false);
    }

    private bool SearchHammerElementInInventory()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.ItemInSlot == metalHammer)
            {
                playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                slot.DeselectItem();
                return true;
            }
        }

        return false;
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
