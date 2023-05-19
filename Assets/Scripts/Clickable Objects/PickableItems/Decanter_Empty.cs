using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decanter_Empty : PickableItem
{
    [SerializeField] private Sprite spriteDecanter;
    public override Sprite GetSpriteToInventory() => spriteDecanter;

    public override void OnClick()
    {
        base.OnClick();
        UIAudioManager.instance.PlayPickupAudio(0.7f);
        GameController.GetInstance().DisplayMessageOnScreen("Графин можно наполнить водой!");
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
