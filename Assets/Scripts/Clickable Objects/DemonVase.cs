using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonVase : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject demonInventory;
    [SerializeField] private PhoneInPlayerRoom phone;
    
    public void OnClick()
    {
        phone.CallAnimationPause(false);
        GameController.GetInstance().SwitchWindow(demonInventory, playerRoomCanvas);
        UIAudioManager.instance.PlayVaseOpen(0.3f);
    }
}

