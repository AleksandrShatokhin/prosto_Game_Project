using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//nonogram room
public class Box_1 : BoxManager
{
    [SerializeField] private GameObject toCloseWindow, toOpenWindow;

    // элементы инвентаря
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private SliderItemClickable sliderItemClicable;

    // основные компоненты элементов на шкатулке
    [SerializeField] Slider slider;
    [SerializeField] Button button_N1, button_N2, button_N3;

    // Параметры для разгадывания кнопочного шифра
    private PickableItem localVariableItemForButtonOnBackPanel;
    [SerializeField] private List<ButtonColor> correctColors;
    [SerializeField] private List<ButtonColor> buttonColors;
    private int indicatorColorList = 0;
    [SerializeField] private Sprite buttonWinSprite;

    void Start()
    {
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
        buttonOpenBox.onClick.AddListener(ClickOpenBox);

        slider.interactable = false;
        localVariableItemForButtonOnBackPanel = null;
    }

    public override void ClickOpenBox()
    {
        if (slider.value == 2 && CheckListButtonColors())
        {
            Debug.Log("Box is open!");

            base.ClickOpenBox();
        }
        else
        {
            buttonColors.Clear();
            indicatorColorList = 0;
            GameController.GetInstance().DisplayMessageOnScreen(messageBoxNotOpen);
        }
    }

    public override void SetClickOnButton(ButtonColor color)
    {
        if (indicatorColorList == correctColors.Count)
        {
            return;
        }

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

        CheckCorrectEnterButtons();
    }

    private void CheckCorrectEnterButtons()
    {
        if (indicatorColorList == correctColors.Count)
        {
            button_N1.GetComponent<Button>().interactable = false;
            button_N1.GetComponent<Image>().sprite = buttonWinSprite;

            button_N2.GetComponent<Button>().interactable = false;
            button_N2.GetComponent<Image>().sprite = buttonWinSprite;

            button_N3.GetComponent<Button>().interactable = false;
            button_N3.GetComponent<Image>().sprite = buttonWinSprite;
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

    public void ClickOnSliderHandler(Image image)
    {
        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == sliderItemClicable)
                {
                    image.sprite = slot.ItemInSlot.GetComponent<SliderItemClickable>().GetSpriteToBox();
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    slider.interactable = true;
                    return;
                }
            }
        }
    }

    public void ClickButtonOnUpPanel()
    {
        GameController.GetInstance().SwitchWindow(this.toOpenWindow, this.toCloseWindow);
    }
}