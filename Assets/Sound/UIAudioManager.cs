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
    public AudioClip UIItemClickAudioClip;
    public AudioClip ChestOpenAudioClip;
    public AudioClip ChestCloseAudioClip;
    public AudioClip ChestBirdAudioClip;
    public AudioClip[] SliderClickAudioClips;
    public AudioClip ChestSliderUnlockedClip;
    public AudioClip ChestButtonsUnlockedClip;
    public AudioClip[] PencilNonogramAudioClip;
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
    public void PlayUIItemClickAudio(float volume)
    {
        _uiAudioSource.volume = 1.0f;
        _uiAudioSource.PlayOneShot(UIItemClickAudioClip, volume);
    }
    public void PlayChestOpenAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestOpenAudioClip, volume);
    }
    public void PlayChestCloseAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestCloseAudioClip, volume);
    }
    public void PlayChestBirdAudio(float volume)
    {
        _uiAudioSource.volume = 1.0f;
        _uiAudioSource.PlayOneShot(ChestBirdAudioClip, volume);
    }
    public void PlaySliderClickAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(SliderClickAudioClips[Random.Range(0, SliderClickAudioClips.Length - 1)], volume);
    }
    public void PlaySliderUnlockedAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestSliderUnlockedClip, volume);
    }
    public void PlayButtonsUnlockedAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestButtonsUnlockedClip, volume);
    }
    public void PlayPencilNonogramPuzzle(float volume)
    {
        _uiAudioSource.pitch = Random.Range(0.98f, 1.02f);
        _uiAudioSource.PlayOneShot(PencilNonogramAudioClip[Random.Range(0, PencilNonogramAudioClip.Length - 1)], volume);
    }
}
