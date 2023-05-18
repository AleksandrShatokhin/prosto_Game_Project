using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour, IClickable
{
    private const string textClickOnRat = "Она так пугающе смотрит на меня!";

    public void OnClick()
    {
        GameController.GetInstance().DisplayMessageOnScreen(textClickOnRat);
    }
}
