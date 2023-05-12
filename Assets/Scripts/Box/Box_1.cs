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

    // �������� ���������
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private SliderItemClickable sliderItemClicable;

    // �������� ���������� ��������� �� ��������
    [SerializeField] Slider slider;
    [SerializeField] Button button_N1, button_N2, button_N3;

    // ��������� ��� ������������ ���������� �����
    private PickableItem localVariableItemForButtonOnBackPanel;
    [SerializeField] private List<ButtonColor> correctColors;
    [SerializeField] private List<ButtonColor> buttonColors;
    private int indicatorColorList = 0;
    [SerializeField] private Sprite buttonWinSprite;

    private bool isCanClickButton;
    private bool isWin;

    void Start()
    {
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
        buttonOpenBox.onClick.AddListener(ClickOpenBox);

        isCanClickButton = false;
        isWin = false;

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
            this.GetComponent<Box1ColorMarkers>().MarkersClear();
            GameController.GetInstance().DisplayMessageOnScreen(messageBoxNotOpen);
        }
    }

    public override void SetClickOnButton(ButtonColor color)
    {
        if (button_N1.GetComponent<ButtonOnPanel>().GetStateButton() == StateButton.Yes
            && button_N2.GetComponent<ButtonOnPanel>().GetStateButton() == StateButton.Yes
            && button_N3.GetComponent<ButtonOnPanel>().GetStateButton() == StateButton.Yes)
        {
            StartCoroutine(ActivateClickToColorButtons());
        }

        if (isCanClickButton == false)
        {
            return;
        }

        buttonColors.Add(color);
        indicatorColorList += 1;

        if (indicatorColorList == correctColors.Count)
        {
            int localIndicator = 0;

            foreach (ButtonColor currentColor in buttonColors)
            {
                if (currentColor == correctColors[localIndicator])
                {
                    localIndicator += 1;
                }
            }

            isWin = (localIndicator == correctColors.Count) ? true : false;

            localIndicator = 0;
            buttonColors.Clear();
            indicatorColorList = 0;
        }

        CheckCorrectEnterButtons();
    }

    private void CheckCorrectEnterButtons()
    {
        if (isWin == true)
        {
            button_N1.GetComponent<Button>().interactable = false;
            button_N1.GetComponent<Image>().sprite = buttonWinSprite;

            button_N2.GetComponent<Button>().interactable = false;
            button_N2.GetComponent<Image>().sprite = buttonWinSprite;

            button_N3.GetComponent<Button>().interactable = false;
            button_N3.GetComponent<Image>().sprite = buttonWinSprite;
        }
    }

    private IEnumerator ActivateClickToColorButtons()
    {
        yield return new WaitForSeconds(0.5f);
        isCanClickButton = true;
        this.GetComponent<Box1ColorMarkers>().IsCanChangeColor_On();
    }

    private bool CheckListButtonColors() => (isWin == true) ? true : false;

    // ������� �� ������� ����� Event
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

    public void OnValueChangedSlider()
    {
        if (slider.value == 2)
        {
            slider.interactable = false;
            StartCoroutine(RotatBox());
        }
    }

    private IEnumerator RotatBox()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        button_N1.GetComponent<ButtonOnPanel>().StartOpanButton();
        button_N2.GetComponent<ButtonOnPanel>().StartOpanButton();
        button_N3.GetComponent<ButtonOnPanel>().StartOpanButton();
    }

    public void ClickButtonOnUpPanel()
    {
        GameController.GetInstance().SwitchWindow(this.toOpenWindow, this.toCloseWindow);
    }
}