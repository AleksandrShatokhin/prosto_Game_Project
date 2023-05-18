using UnityEngine;

public class HintManager : MonoBehaviour
{
    public void CloseHint()
    {
        this.gameObject.SetActive(false);
        UIAudioManager.instance.PlayPaperAudio(0.3f);
    }
}
