using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCandles : MonoBehaviour
{
    [SerializeField] private Image createdSymbol_1, createdSymbol_2;

    public void ClickCheckButton()
    {
        if (createdSymbol_1.sprite == null || createdSymbol_2.sprite == null)
        {
            GameController.GetInstance().DisplayMessageOnScreen("ВВедены не все символы");
            return;
        }

        if ((createdSymbol_1.sprite.name == "Symbol_P + Symbol_=" || createdSymbol_1.sprite.name == "Symbol_= + Symbol_P") 
            && (createdSymbol_2.sprite.name == "Symbol_S + Symbol_II" || createdSymbol_2.sprite.name == "Symbol_II + Symbol_S"))
        {
            GameController.GetInstance().DisplayMessageOnScreen("ВВедены правельные символы");
        }
        else
        {
            GameController.GetInstance().DisplayMessageOnScreen("ВВедены неверные символы");
        }
    }

    public void ClickRemoveButton()
    {
        if (createdSymbol_1.sprite == null && createdSymbol_2.sprite == null)
        {
            return;
        }

        createdSymbol_1.sprite = null;
        createdSymbol_2.sprite = null;
    }
}
