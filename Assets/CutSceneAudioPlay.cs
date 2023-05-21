using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAudioPlay : MonoBehaviour
{
    public AudioSource cutscene;
    public void PlayCutsceneAudio()
    {
        cutscene.Play();
    }
}
