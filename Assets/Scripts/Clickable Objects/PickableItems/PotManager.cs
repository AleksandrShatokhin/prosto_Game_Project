using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotManager : PickableItem
{
    [SerializeField] private SoupRecipeWindow soupRecipe_Window;
    [SerializeField] private List<PickableItem> correctIngredients;
    [SerializeField] private List<PickableItem> soupIngredients;
    [SerializeField] private GameObject bowlSoup;

    public List<PickableItem> GetSoupIngredients() => soupIngredients;

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
                int numberLoop = 0;

                foreach (PickableItem correctIngredients in correctIngredients)
                {
                    if (slot.ItemInSlot == correctIngredients)
                    {
                        soupIngredients.Add(slot.ItemInSlot);
                        soupRecipe_Window.AddMark(numberLoop);
                        playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                        slot.DeselectItem();
                    }

                    numberLoop += 1;
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
