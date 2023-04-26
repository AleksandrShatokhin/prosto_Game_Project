using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTextMessage : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(TimerToDisable());
    }

    private IEnumerator TimerToDisable(int delay = 1)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
