using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour, IClickable
{
    private const string nonArrows = "Кажется этим часам не достает стрелок!?", withArrow = "Часы показывают 14:55. Возможно это шифр!?";

    [SerializeField] private GameObject arrowsInClock;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PickableItem arrows;

    public void OnClick()
    {
        if (arrowsInClock.activeInHierarchy == true)
        {
            GameController.GetInstance().DisplayMessageOnScreen(withArrow);
            return;
        }

        if (IsArrowsInInventory() == false)
        {
            GameController.GetInstance().DisplayMessageOnScreen(nonArrows);
        }
        else
        {
            arrowsInClock.SetActive(true);
        }
    }

    private bool IsArrowsInInventory()
    {
        bool isArrowsInInventory = false;

        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == arrows)
                {
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return isArrowsInInventory = true;
                }
            }
        }

        return isArrowsInInventory;
    }
}
