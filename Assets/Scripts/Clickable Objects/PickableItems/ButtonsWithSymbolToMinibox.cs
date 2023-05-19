using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsWithSymbolToMinibox : PickableItem
{
    [SerializeField] private Sprite spriteButtonToInventory;
    public override Sprite GetSpriteToInventory() => spriteButtonToInventory;

    [SerializeField] private SpriteRenderer sr_Button_1, sr_Button_2;
    [SerializeField] private Sprite button_1_SpriteSymbol, button_2_SpriteSymbol;
    [SerializeField] private bool isButton_1_Activate, isButton_2_Activate;

    private void Start()
    {
        isButton_1_Activate = false;
        isButton_2_Activate = false;
    }

    public override void OnClick()
    {
        if (CheckActivationButtons() == true)
        {
            base.OnClick();
            UIAudioManager.instance.PlayPickupAudio(0.7f);
        }
    }

    private bool CheckActivationButtons()
    {
        if (isButton_1_Activate == false && isButton_2_Activate == false)
        {
            GameController.GetInstance().DisplayMessageOnScreen("Эти кнопки кажутся такими пустыми...");
            return false;
        }

        if (isButton_1_Activate == true && isButton_2_Activate == false || isButton_1_Activate == false && isButton_2_Activate == true)
        {
            GameController.GetInstance().DisplayMessageOnScreen("Осталось активировать еще одну кнопку");
            return false;
        }

        return true;
    }

    public void ActivateButton_1()
    {
        isButton_1_Activate = true;
        sr_Button_1.sprite = button_1_SpriteSymbol;
        SwitchLayer();
    }

    public void ActivateButton_2()
    {
        isButton_2_Activate = true;
        sr_Button_2.sprite = button_2_SpriteSymbol;
        SwitchLayer();
    }

    private void SwitchLayer()
    {
        if (isButton_1_Activate == true && isButton_2_Activate == true)
        {
            this.gameObject.layer = (int)Layers.Pickable;
        }
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
