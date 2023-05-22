using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCaptureAudio : MonoBehaviour
{
    public void PlayDemonCaptureAudio()
    {
        UIAudioManager.instance.PlayDemonCapture(1f);
    }
}
