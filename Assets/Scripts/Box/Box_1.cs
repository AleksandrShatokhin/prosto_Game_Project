using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Box_1 : BoxManager
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] private CircleForBox circleForBox;

    [SerializeField] Button buttonLeft, buttonRight, buttonOpenBox;
    [SerializeField] Slider slider;
    [SerializeField] Button button_N1, button_N2, button_N3;

    private PickableItem localVariableItemForButtonOnBackPanel;

    void Start()
    {
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
        buttonOpenBox.onClick.AddListener(ClickOpenBox);

        slider.interactable = false;
        localVariableItemForButtonOnBackPanel = null;
    }

    private void ClickButtonLeft()
    {
        this.gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
    }

    private void ClickButtonRight()
    {
        this.gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);
    }

    private void ClickOpenBox()
    {
        if (slider.value == 1 && sumOfClick == 6)
        {
            Debug.Log("Box is open!");
        }
        else
        {
            sumOfClick = 0;
            Debug.Log("Box is not open!");
        }
    }

    public override void CounterSumOfClick(int value)
    {
        sumOfClick += value;
        Debug.Log(sumOfClick);
    }

    // Вызываю на кнопках через Event
    public void ClickButtonOnBackPanel(PickableItem buttonWithNumber)
    {
        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == buttonWithNumber)
                {
                    localVariableItemForButtonOnBackPanel = slot.ItemInSlot;
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return;
                }
            }
        }
    }

    public void ClickButtonOnBackPanel(Button button)
    {
        if (localVariableItemForButtonOnBackPanel != null)
        {
            button.GetComponent<ButtonOnPanel>().SetItem(localVariableItemForButtonOnBackPanel);
            localVariableItemForButtonOnBackPanel = null;
        }
    }

    public void ClickToCloseBox(GameObject roomCanvas)
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        roomCanvas.SetActive(true);
    }

    public void ClickOnSliderHandler(Image image)
    {
        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == circleForBox)
                {
                    image.sprite = slot.ItemInSlot.GetComponent<SpriteRenderer>().sprite;
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    slider.interactable = true;
                    return;
                }
            }
        }
    }
}