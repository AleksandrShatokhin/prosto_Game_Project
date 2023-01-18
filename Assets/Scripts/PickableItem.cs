using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Items itemType;
    [SerializeField] private PlayerInventory playerInventory;
    private bool wasItemPicked = false;
    [SerializeField] private TMP_Text buttonText;

    public void OnAddItemButtonClicked()
    {
        if (!playerInventory.TakenItems.Contains(itemType))
        {
            playerInventory.AddItemToInventory(itemType);
            buttonText.text = "Put " + itemType.ToString() + " back";
        }
        else
        {
            playerInventory.RemoveItemFromInventory(itemType);
            buttonText.text = "Take " + itemType.ToString();
        }
    }
}
