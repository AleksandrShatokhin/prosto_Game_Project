using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPhoneAudio : MonoBehaviour
{
    public AudioClip[] ClickAudioClips;
    public AudioClip PickUpAudioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourcePickUp;
    public void PlayPhoneRingAudio()
    {
        audioSource.PlayOneShot(ClickAudioClips[Random.Range(0, ClickAudioClips.Length - 1)]);
    }
    public void PlayPhonePickUpAudio()
    {
        audioSourcePickUp.PlayOneShot(PickUpAudioClip);
    }
}
