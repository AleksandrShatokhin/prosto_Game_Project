using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonInventorySlot : MonoBehaviour
{
    [SerializeField] private DemonInventory demonInventory;

    public DemonSO demonSO;
    [SerializeField] private Image slotImage;

    public void ConfigureSlot()
    {
        slotImage.sprite = demonSO.inventorySprite;
        slotImage.gameObject.SetActive(true);
    }

    public void OnDemonButtonClicked()
    {
        demonInventory.ChangeCurrentDemon(demonSO);
    }
}
