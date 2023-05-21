using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTextMessage : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(TimerToDisable());
    }

    private IEnumerator TimerToDisable(float delay = 0.7f)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
