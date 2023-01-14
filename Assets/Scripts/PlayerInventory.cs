using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Items> takenItems = new List<Items>();
    
    public void AddItemToInventory(Items itemToAdd)
    {
        if (!takenItems.Contains(itemToAdd))
        {
            takenItems.Add(itemToAdd);
        }
        else
        {
            Debug.Log("Item already exists in your inventory");
        }

        foreach (var item in takenItems)
        {
            Debug.Log(item);
        }
    }

}

