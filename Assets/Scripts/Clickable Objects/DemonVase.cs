using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonVase : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject demonInventory;
    
    public void OnClick()
    {
        GameController.GetInstance().SwitchWindow(demonInventory, playerRoomCanvas);
        UIAudioManager.instance.PlayVaseOpen(0.6f);
    }
}

