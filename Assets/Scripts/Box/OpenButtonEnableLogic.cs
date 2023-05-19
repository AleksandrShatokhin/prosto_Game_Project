using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButtonEnableLogic : MonoBehaviour
{
    [SerializeField] private GameObject openBoxButton;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PickableItem hammer;

    private void OnEnable()
    {
        StartCoroutine(StartChecingInventory());
    }

    private IEnumerator StartChecingInventory()
    {
        while (true)
        {
            if (CheckInventory() == true)
            {
                openBoxButton.SetActive(true);
            }
            else
            {
                openBoxButton.SetActive(false);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    private bool CheckInventory()
    {
        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == hammer)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
