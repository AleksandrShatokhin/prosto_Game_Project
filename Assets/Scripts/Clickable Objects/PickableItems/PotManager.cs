using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotManager : PickableItem
{
    [SerializeField] private List<PickableItem> correctIngredients;
    [SerializeField] private List<PickableItem> soupIngredients;
    [SerializeField] private GameObject bowlSoup;

    public override void OnClick()
    {
        if (CheckerSoup() == true)
        {
            GameController.GetInstance().DisplayMessageOnScreen("Суп готов!");
            soupIngredients.Clear();
            bowlSoup.SetActive(true);
        }
        else
        {
            AddIngredientInPot();
        }
    }

    private void AddIngredientInPot()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                foreach (PickableItem correctIngredients in correctIngredients)
                {
                    if (slot.ItemInSlot == correctIngredients)
                    {
                        soupIngredients.Add(slot.ItemInSlot);
                        playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                        slot.DeselectItem();
                    }
                }
            }
        }
    }

    public bool CheckerSoup() => (soupIngredients.Count == correctIngredients.Count) ? true : false;

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
