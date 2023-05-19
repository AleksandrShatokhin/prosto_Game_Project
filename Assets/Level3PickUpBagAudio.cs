using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PickUpBagAudio : MonoBehaviour
{
    public void PlayPickUpAudio()
    {
        UIAudioManager.instance.PlayPickupAudio(0.5f);
    }
}
