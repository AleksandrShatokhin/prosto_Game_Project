using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Items> takenItems = new List<Items>();
    [SerializeField] private int maxNumberOfItemsInInventory = 2;
    [SerializeField] GameObject infoWindow;

    public bool AddItemToInventory(Items itemToAdd)
    {
        if (!(takenItems.Count >= maxNumberOfItemsInInventory))
        {
            takenItems.Add(itemToAdd);
            Debug.Log("Added " + itemToAdd.ToString() + " to inventory");
            return true;
        }
        else
        {
            infoWindow.GetComponent<InformationWindow>().SetWindowText("Ваш инвентарь заполнен");
            Instantiate(infoWindow, transform.position, Quaternion.identity);
            return false;
        }
    }

    public void RemoveItemFromInventory(Items itemToRemove)
    {
        takenItems.Remove(itemToRemove);
        Debug.Log("Item already exists in your inventory, putting it back");
    }

    public List<Items> TakenItems => takenItems;

}

