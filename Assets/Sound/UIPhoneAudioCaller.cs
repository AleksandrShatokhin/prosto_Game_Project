using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPhoneAudioCaller : MonoBehaviour
{
    public UIPhoneAudio uiPhoneAudio;
    public void PlayPhoneAudio()
    {
        uiPhoneAudio.PlayPhoneRingAudio();
    }
}
