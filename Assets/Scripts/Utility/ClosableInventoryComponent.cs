using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosableInventoryComponent : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject arrowToBack;

    public void SetInventoryObject(GameObject inventoryObject) => inventory = inventoryObject;
    public void RemoveInventoryObject() => inventory = null;

    private void OnEnable()
    {
        if (inventory != null)
        {
            inventory.SetActive(false);
        }

        if (arrowToBack != null)
        {
            arrowToBack.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (inventory != null)
        {
            inventory.SetActive(true);
        }

        if (arrowToBack != null)
        {
            arrowToBack.SetActive(true);
        }
    }
}
