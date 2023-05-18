using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonogramBoxAudioManager : MonoBehaviour
{
    public AudioClip[] ArrowClicks;
    public AudioClip[] ButtonPressed;
    [SerializeField] public AudioSource _uiAudioSource;
    public void PlayArrowClickAudio()
    {
        _uiAudioSource.volume = 0.2f;
        _uiAudioSource.PlayOneShot(ArrowClicks[Random.Range(0, ArrowClicks.Length - 1)]);
    }
    public void PlayButtonPressedAudio()
    {
        _uiAudioSource.PlayOneShot(ButtonPressed[Random.Range(0, ButtonPressed.Length - 1)]);
    }
    public void PlaySomethingAudio(float volume)
    {
        _uiAudioSource.PlayOneShot(ButtonPressed[Random.Range(0, ButtonPressed.Length - 1)], volume);
    }
}
