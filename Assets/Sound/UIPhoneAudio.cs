using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPhoneAudio : MonoBehaviour
{
    public AudioClip[] ClickAudioClips;
    [SerializeField] private AudioSource audioSource;
    public void PlayPhoneRingAudio()
    {
        audioSource.PlayOneShot(ClickAudioClips[Random.Range(0, ClickAudioClips.Length - 1)]);
    }
}
