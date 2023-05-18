using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAudio : MonoBehaviour
{
    private float _timer;
    private float _startTime;
    private void Start()
    {
        _timer = Random.Range(0, 15f);
        _startTime = 10f;
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            UIAudioManager.instance.PlayMouseAudio(0.7f);
            _timer = _startTime + Random.Range(0, 10f);
        }
    }
}
