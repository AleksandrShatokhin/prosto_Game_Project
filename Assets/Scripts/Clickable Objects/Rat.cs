using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour, IClickable
{
    private const string textClickOnRat = "��� ��� ������� ������� �� ����!";

    public void OnClick()
    {
        GameController.GetInstance().DisplayMessageOnScreen(textClickOnRat);
    }
}
