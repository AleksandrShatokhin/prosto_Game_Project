using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDog : PickableItem
{
    private Vector2 defaultLocalPosition = new Vector2(-4.5f, 2.0f);
    private Vector3 righttLocalPosition = new Vector3(4.5f, -2.0f, -0.01f);

    [SerializeField] private GameObject canvasText;
    [SerializeField] private PickableItem bowlSoup_Type;

    public override void OnClick()
    {
        if (TakingSoup() == false)
        {
            canvasText.SetActive(true);
        }
        else
        {
            transform.localPosition = righttLocalPosition;
        }
    }

    private bool TakingSoup()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == bowlSoup_Type)
                {
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return true;
                }
            }
        }

        return false;
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
