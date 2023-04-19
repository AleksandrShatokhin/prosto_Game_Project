using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : PickableItem
{
    private const string text_1 = "�� ���� ������� ����� �� �������� ����...";
    private const string text_2 = "������ ������� ������. ��������� �� ��";
    private const string text_3 = "��� �� �������� �������. �������� ��� ����";

    [SerializeField] private GameObject drops, closedLayer;
    [SerializeField] private PickableItem sprayType, ragType;

    private void Start()
    {
        drops.SetActive(false);
    }

    public override void OnClick()
    {
        if (drops.activeInHierarchy == false && closedLayer.activeInHierarchy == false)
        {
            GameController.GetInstance().DisplayMessageOnScreen(text_3);
            return;
        }

        if (drops.activeInHierarchy == false)
        {
            if (SearchSprayInInventory() == false)
            {
                GameController.GetInstance().DisplayMessageOnScreen(text_1);
            }
            else
            {
                GameController.GetInstance().DisplayMessageOnScreen(text_2);
            }
        }
        else
        {
            SearchRagInInventory();
        }
    }

    private bool SearchSprayInInventory()
    {
        bool isSprayFound = false;

        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == sprayType)
                {
                    drops.SetActive(true);
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return isSprayFound = true;
                }
            }
        }

        return isSprayFound;
    }

    private void SearchRagInInventory()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == ragType)
                {
                    drops.SetActive(false);
                    closedLayer.SetActive(false);
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                }
            }
        }
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
