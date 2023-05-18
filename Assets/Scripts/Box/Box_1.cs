using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//nonogram room
public class Box_1 : BoxManager
{
    [SerializeField] private GameObject toCloseWindow, toOpenWindow;
    [SerializeField] private PlayerInventory inventory;
    public PlayerInventory GetPlayerInventory() => inventory;

    [SerializeField] Button button_N1, button_N2, button_N3;

    private PickableItem localVariableItemForButtonOnBackPanel;
    [SerializeField] private List<ButtonColor> correctColors;
    [SerializeField] private List<ButtonColor> buttonColors;
    private int indicatorColorList;
    [SerializeField] private int counterToHint;

    private bool isCanClickButton;
    private bool isWin;
    public bool GetIsWin() => isWin;

    void Start()
    {
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
        buttonOpenBox.onClick.AddListener(ClickOpenBox);

        isCanClickButton = false;
        isWin = false;

        indicatorColorList = 0;
        counterToHint = 0;

        localVariableItemForButtonOnBackPanel = null;
    }

    public override void ClickOpenBox()
    {
        if (CheckListButtonColors())
        {
            base.ClickOpenBox();
            UIAudioManager.instance.PlayChestOpenAudio(0.7f);
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
        UIAudioManager.instance.PlaySliderClickAudio(0.6f);

        if (indicatorColorList == correctColors.Count)
        {
            counterToHint += 1;

            int localIndicator = 0;

            foreach (ButtonColor currentColor in buttonColors)
            {
                if (currentColor == correctColors[localIndicator])
                {
                    localIndicator += 1;
                }
            }

            isWin = (localIndicator == correctColors.Count) ? true : false;

            if (isWin == false && counterToHint == 3)
            {
                GameController.GetInstance().DisplayMessageOnScreen("Возможно стоит поискать в комнате подсказку!");
                counterToHint = 0;
            }

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
            button_N2.GetComponent<Button>().interactable = false;
            button_N3.GetComponent<Button>().interactable = false;

            UIAudioManager.instance.PlayButtonsUnlockedAudio(0.6f);
        }
    }

    private IEnumerator ActivateClickToColorButtons()
    {
        yield return new WaitForSeconds(0.5f);
        isCanClickButton = true;
        this.GetComponent<Box1ColorMarkers>().IsCanChangeColor_On();
    }

    private bool CheckListButtonColors() => (isWin == true) ? true : false;

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
            UIAudioManager.instance.PlaySliderClickAudio(0.6f);
        }
    }

    public override void CloseBox()
    {
        base.CloseBox();
        UIAudioManager.instance.PlayChestCloseAudio(0.75f);
    }

    public void ButtonOnPanelApperance()
    {
        button_N1.GetComponent<ButtonOnPanel>().StartOpanButton();
        button_N2.GetComponent<ButtonOnPanel>().StartOpanButton();
        button_N3.GetComponent<ButtonOnPanel>().StartOpanButton();
    }

    public void ClickButtonOnUpPanel()
    {
        GameController.GetInstance().SwitchWindow(this.toOpenWindow, this.toCloseWindow);
        UIAudioManager.instance.PlayChestBirdAudio(0.5f);
    }
}