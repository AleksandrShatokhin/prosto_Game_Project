using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Items> takenItems = new List<Items>();

    public void AddItemToInventory(Items itemToAdd)
    {
        takenItems.Add(itemToAdd);
        Debug.Log("Added " + itemToAdd.ToString() + " to inventory");
    }

    public void RemoveItemFromInventory(Items itemToRemove)
    {
        takenItems.Remove(itemToRemove);
        Debug.Log("Item already exists in your inventory, putting it back");
    }

    public List<Items> TakenItems => takenItems;

}

