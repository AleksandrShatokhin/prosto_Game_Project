using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject necronomiconCanvas;
    public UIAudioManager AudioManager;
    [SerializeField] private PhoneInPlayerRoom phone;
    
    public void OnClick()
    {
        phone.CallAnimationPause(false);
        AudioManager.PlayPaperAudio(0.4f);
        GameController.GetInstance().SwitchWindow(necronomiconCanvas, playerRoomCanvas);
    }
}
