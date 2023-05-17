using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPhoneAudio : MonoBehaviour
{
    public AudioClip[] PhoneAudioClips;
    [SerializeField] private AudioSource _uiAudioSource;
    public void PlayPhoneRingAudio()
    {
        _uiAudioSource.PlayOneShot(PhoneAudioClips[Random.Range(0, PhoneAudioClips.Length - 1)]);
    }
}
