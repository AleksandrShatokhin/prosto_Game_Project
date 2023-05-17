using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject necronomiconCanvas;
    public UIAudioManager AudioManager;
    
    public void OnClick()
    {
        AudioManager.PlayPaperAudio(0.4f);
        GameController.GetInstance().SwitchWindow(necronomiconCanvas, playerRoomCanvas);
    }
}
