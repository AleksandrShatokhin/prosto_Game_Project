using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicReplay : MonoBehaviour
{
    public AudioSource musicSource;
    private float startTimer = 240.0f;
    private float Timer = 240f;
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            musicSource.Play();
            Timer = startTimer;
        }
    }
}
