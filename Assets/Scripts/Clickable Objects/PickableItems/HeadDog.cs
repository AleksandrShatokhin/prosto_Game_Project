using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDog : PickableItem
{
    private Vector2 defaultLocalPosition = new Vector3(3.2f, 1.5f, -0.02f);
    private Vector3 righttLocalPosition = new Vector3(-3.2f, 1.5f, -0.02f);

    [SerializeField] private GameObject canvasText;
    [SerializeField] private PickableItem bowlSoup_Type;
    [SerializeField] private AudioClip audioDogBarking;

    public override void OnClick()
    {
        if (TakingSoup() == false)
        {
            canvasText.SetActive(true);
            GameController.GetInstance().PlaySimpleAudio(audioDogBarking);
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
