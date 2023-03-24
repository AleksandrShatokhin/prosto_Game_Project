using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Box_1 : BoxManager
{
    // элементы инвентаря
    [SerializeField] PlayerInventory inventory;
    [SerializeField] private SliderItemClickable sliderItemClicable;

    // основные компоненты элементов на шкатулке
    [SerializeField] Button buttonLeft, buttonRight, buttonOpenBox;
    [SerializeField] Slider slider;
    [SerializeField] Button button_N1, button_N2, button_N3;

    // Параметры для разгадывания кнопочного шифра
    private PickableItem localVariableItemForButtonOnBackPanel;
    [SerializeField] private List<ButtonColor> correctColors;
    [SerializeField] private List<ButtonColor> buttonColors;
    private int indicatorColorList = 0;

    void Start()
    {
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
        buttonOpenBox.onClick.AddListener(ClickOpenBox);

        slider.interactable = false;
        localVariableItemForButtonOnBackPanel = null;
    }

    private void ClickButtonLeft() => this.gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
    private void ClickButtonRight() => this.gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);

    public override void ClickOpenBox()
    {
        if (slider.value == 2 && CheckListButtonColors())
        {
            Debug.Log("Box is open!");

            base.ClickOpenBox();
            buttonLeft.gameObject.SetActive(false);
            buttonRight.gameObject.SetActive(false);
            buttonOpenBox.gameObject.SetActive(false);
        }
        else
        {
            buttonColors.Clear();
            indicatorColorList = 0;
            Debug.Log("Box is not open!");
        }
    }

    public override void SetClickOnButton(ButtonColor color)
    {
        if (correctColors[indicatorColorList] == color)
        {
            buttonColors.Add(color);
            indicatorColorList += 1;
        }
        else
        {
            buttonColors.Clear();
            indicatorColorList = 0;
        }
    }

    private bool CheckListButtonColors()
    {
        bool isCorrectCombination = (buttonColors.Count == correctColors.Count) ? true : false;
        return isCorrectCombination;
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

    public override void CloseBox()
    {
        base.CloseBox();
    }

    //public void ClickToCloseBox(GameObject roomCanvas)
    //{
    //    this.gameObject.transform.parent.gameObject.SetActive(false);
    //    //roomCanvas.SetActive(true);
    //}

    public void ClickOnSliderHandler(Image image)
    {
        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == sliderItemClicable)
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