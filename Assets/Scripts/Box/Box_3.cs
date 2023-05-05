using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_3 : BoxManager
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private Hammer hammer;

    private void Start()
    {
        buttonOpenBox.onClick.AddListener(ClickOpenBox);
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
    }

    public override void ClickOpenBox()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == hammer)
                {
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();

                    base.ClickOpenBox();

                    return;
                }
            }
        }

        GameController.GetInstance().DisplayMessageOnScreen("У этой шкатулки нет замков. Нужно придумать как еще ее можно вскрыть...");
    }
}
