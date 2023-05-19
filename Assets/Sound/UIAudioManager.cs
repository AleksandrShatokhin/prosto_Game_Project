using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;

    [Header("UI Sound")]
    public AudioClip[] Hover;
    public AudioClip[] ButtonClick;
    public AudioClip[] Click;
    public AudioClip[] Paper;
    public AudioClip[] PickUp;
    public AudioClip UIClick;

    [Header("General")]
    public AudioClip[] BookshelfSlide;
    public AudioClip ChestOpen;
    public AudioClip ChestClose;
    public AudioClip[] SliderClick;

    [Header("Level Nanogram")]
    public AudioClip ChestBirdPickUp;
    public AudioClip ChestUnlockedSlider;
    public AudioClip ChestUnlockedButtons;
    public AudioClip[] PuzzlePencil;

    [Header("Level Mouse")]
    public AudioClip LampTurn;
    public AudioClip[] Mouse;
    public AudioClip Spray;
    public AudioClip Wiping;
    public AudioClip Clock;
    public AudioClip[] PourFlasks;


    [Header("Level Fridge")]
    public AudioClip[] PotDropItem;
    public AudioClip PotCooking;
    public AudioClip WaterToBottle;
    public AudioClip Soda;
    public AudioClip Vinegar;

    [SerializeField] public AudioSource _uiAudioSource;

    private void Start()
    {
        instance = this;
    }
    public void PlayHoverAudio()
    {
        _uiAudioSource.volume = 0.2f;
        _uiAudioSource.PlayOneShot(Hover[Random.Range(0, Hover.Length - 1)]);
    }
    public void PlayClickAudio()
    {
        _uiAudioSource.PlayOneShot(ButtonClick[Random.Range(0, ButtonClick.Length - 1)]);
    }
    public void PlayPaperAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(Paper[Random.Range(0, Paper.Length - 1)], volume);
    }
    public void PlayClickSoftAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(Click[Random.Range(0, Click.Length - 1)], volume);
    }
    public void PlayPickupAudio(float volume)
    {
        volume -= 0.2f;
        _uiAudioSource.PlayOneShot(PickUp[Random.Range(0, PickUp.Length - 1)], volume);
    }
    public void PlayShelfSlideAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(BookshelfSlide[Random.Range(0, BookshelfSlide.Length - 1)], volume);
    }
    public void PlayUIItemClickAudio(float volume)
    {
        _uiAudioSource.volume = 1.0f;
        _uiAudioSource.PlayOneShot(UIClick, volume);
    }
    public void PlayChestOpenAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestOpen, volume);
    }
    public void PlayChestCloseAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestClose, volume);
    }
    public void PlayChestBirdAudio(float volume)
    {
        _uiAudioSource.volume = 1.0f;
        _uiAudioSource.PlayOneShot(ChestBirdPickUp, volume);
    }
    public void PlaySliderClickAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(SliderClick[Random.Range(0, SliderClick.Length - 1)], volume);
    }
    public void PlaySliderUnlockedAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestUnlockedSlider, volume);
    }
    public void PlayButtonsUnlockedAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestUnlockedButtons, volume);
    }
    public void PlayPencilNonogramPuzzle(float volume)
    {
        _uiAudioSource.pitch = Random.Range(0.98f, 1.02f);
        _uiAudioSource.PlayOneShot(PuzzlePencil[Random.Range(0, PuzzlePencil.Length - 1)], volume);
    }

    public void PlayLampTurnAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ChestUnlockedButtons, volume);
    }
    public void PlayMouseAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(Mouse[Random.Range(0, Mouse.Length - 1)], volume);
    }
    public void PlaySpraySound(float volume)
    {
        _uiAudioSource.PlayOneShot(Spray, volume);
    }
    public void PlayWipingSound(float volume)
    {
        _uiAudioSource.PlayOneShot(Wiping, volume);
    }
    public void PlayClockAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(Clock, volume);
    }
    public void PlayPourWaterAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(PourFlasks[Random.Range(0, PourFlasks.Length - 1)], volume);
    }
    public void PlayPotDropAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(PotDropItem[Random.Range(0, PotDropItem.Length - 1)], volume);
    }
    public void PlayCookingAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(PotCooking, volume);
    }
    public void PlayWaterToBottle(float volume)
    {
        _uiAudioSource.PlayOneShot(WaterToBottle, volume);
    }
    public void PlaySoda(float volume)
    {
        _uiAudioSource.PlayOneShot(Soda, volume);
    }
    public void PlayVinegar(float volume)
    {
        _uiAudioSource.PlayOneShot(Vinegar, volume);
    }
}
