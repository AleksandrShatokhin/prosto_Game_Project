using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_2 : BoxManager
{
    [SerializeField] private Button buttonOpenBox;

    private void Start()
    {
        buttonOpenBox.onClick.AddListener(ClickOpenBox);
    }

    public override void ClickOpenBox()
    {
        base.ClickOpenBox();
    }
}
