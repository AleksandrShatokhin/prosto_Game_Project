using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public AudioClip[] HoverAudioClips;
    public AudioClip[] ClickAudioClips;
    public void PlayHoverAudio()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(HoverAudioClips[Random.Range(0, HoverAudioClips.Length - 1)]);
    }
    public void PlayClickAudio()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(ClickAudioClips[Random.Range(0, ClickAudioClips.Length - 1)]);
    }
}
