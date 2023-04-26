using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class KitchenFaucet : PickableItem
{
    [SerializeField] private GameObject decanterWater;
    [SerializeField] private PickableItem decanterEmpty;
    [SerializeField] private bool isWaterActivate;

    public override void OnClick()
    {
        if (isWaterActivate == true)
        {
            FillDecanterWoter();
        }
        else
        {
            SwitcherKitchenFaucet();
        }
    }

    private void SwitcherKitchenFaucet() => isWaterActivate = !isWaterActivate;

    private void FillDecanterWoter()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true && slot.ItemInSlot == decanterEmpty)
            {
                playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                slot.DeselectItem();
                decanterWater.GetComponent<IClickable>()?.OnClick();
            }
            else
            {
                SwitcherKitchenFaucet();
            }
        }
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
