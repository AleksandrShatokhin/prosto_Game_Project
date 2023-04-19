using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickableItem
{
    private const string nonArrows = "������� ���� ����� �� ������� �������!?", withArrow = "���� ���������� 14:55. �������� ��� ����!?";

    public override void OnClick()
    {
        GameController.GetInstance().DisplayMessageOnScreen(nonArrows);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
