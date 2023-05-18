using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewspaperManager : MonoBehaviour
{

    public void CloseNewspaper()
    {
        this.gameObject.SetActive(false);
        UIAudioManager.instance.PlayPaperAudio(0.3f);
    }
}
