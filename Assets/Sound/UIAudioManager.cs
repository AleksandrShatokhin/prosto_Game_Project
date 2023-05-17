using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public AudioClip[] HoverAudioClips;
    public AudioClip[] ClickAudioClips;
    public AudioClip[] PaperAudioClips;
    [SerializeField] private AudioSource _uiAudioSource;
    public void PlayHoverAudio()
    {
        _uiAudioSource.volume = 0.2f;
        _uiAudioSource.PlayOneShot(HoverAudioClips[Random.Range(0, HoverAudioClips.Length - 1)]);
    }
    public void PlayClickAudio()
    {
        _uiAudioSource.PlayOneShot(ClickAudioClips[Random.Range(0, ClickAudioClips.Length - 1)]);
    }
    public void PlayPaperAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(PaperAudioClips[Random.Range(0, PaperAudioClips.Length - 1)], volume);
    }
}
