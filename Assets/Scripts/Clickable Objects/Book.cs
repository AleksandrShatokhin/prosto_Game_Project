using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject necronomiconCanvas;
    
    public void OnClick()
    {
        GameController.GetInstance().SwitchWindow(necronomiconCanvas, playerRoomCanvas);
    }
}
