using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircumventBanRaycast : MonoBehaviour
{
    private MouseHandler mouseHandler;

    private void OnEnable()
    {
        mouseHandler = GameController.GetInstance().GetComponent<MouseHandler>();
        mouseHandler.IsCircumventBanRaycast_On();
    }
    private void OnDisable()
    {
        mouseHandler = GameController.GetInstance().GetComponent<MouseHandler>();
        mouseHandler.IsCircumventBanRaycast_Off();
    }
}
