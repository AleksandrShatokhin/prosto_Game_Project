using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInDemonRoom : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject boxWindow;
    [SerializeField] private GameObject canvas;

    void IClickable.OnClick()
    {
        GameController.GetInstance().SwitchWindow(boxWindow, canvas);
    }
}
