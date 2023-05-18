using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IClickable
{
    private const string textForLight_On = "Уже включено. Отметины на лампочке отразили код!";
    private const string textForLight_Off = "Нужно найти лампочку!";

    [SerializeField] private GameObject lightBulb;

    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PickableItem lightBulbInRoom_Type;

    public void OnClick()
    {
        if (lightBulb.activeInHierarchy == true)
        {
            GameController.GetInstance().DisplayMessageOnScreen(textForLight_On);
            return;
        }
        else
        {
            if (SwitcherLight() == true)
            {
                return;
            }

            GameController.GetInstance().DisplayMessageOnScreen(textForLight_Off);
        }
    }

    private bool SwitcherLight()
    {
        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == lightBulbInRoom_Type)
                {
                    lightBulb.SetActive(true);
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    UIAudioManager.instance.PlayLampTurnAudio(0.7f);
                    return true;
                }
            }
        }

        return false;
    }
}
