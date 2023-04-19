using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickableItem
{
    private const string nonArrows = "Кажется этим часам не достает стрелок!?", withArrow = "Часы показывают 14:55. Возможно это шифр!?";

    public override void OnClick()
    {
        GameController.GetInstance().DisplayMessageOnScreen(nonArrows);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
