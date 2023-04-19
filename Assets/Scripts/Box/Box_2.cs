using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//cups room
public class Box_2 : BoxManager
{
    private void Start()
    {
        buttonOpenBox.onClick.AddListener(ClickOpenBox);
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
    }

    public override void ClickOpenBox()
    {
        base.ClickOpenBox();
    }
}
