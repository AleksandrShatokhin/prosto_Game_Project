using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladle : PickableItem
{
    [SerializeField] private PotManager potManager;

    public override void OnClick()
    {
        if (potManager.CheckerSoup() == true)
        {
            base.OnClick();
        }
        else
        {
            GameController.GetInstance().DisplayMessageOnScreen("Сначала нужно собрать все ингредиенты супа!");
        }
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
