using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;
    public AudioClip[] HoverAudioClips;
    public AudioClip[] ClickAudioClips;
    public AudioClip[] ClickSoftAudioClips;
    public AudioClip[] PaperAudioClips;
    public AudioClip[] UIButtonPickUpAudioClips;
    public AudioClip[] ShelfSlideAudioClips;
    [SerializeField] public AudioSource _uiAudioSource;
    private void Start()
    {
        instance = this;
    }
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
    public void PlayClickSoftAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ClickSoftAudioClips[Random.Range(0, ClickSoftAudioClips.Length - 1)], volume);
    }
    public void PlayButtonPickupAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(UIButtonPickUpAudioClips[Random.Range(0, UIButtonPickUpAudioClips.Length - 1)], volume);
    }
    public void PlayShelfSlideAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ShelfSlideAudioClips[Random.Range(0, ShelfSlideAudioClips.Length - 1)], volume);
    }
}
