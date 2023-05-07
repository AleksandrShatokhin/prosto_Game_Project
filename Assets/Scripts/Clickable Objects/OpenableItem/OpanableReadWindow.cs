using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpanableReadWindow : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject opanableWindow;

    public void OnClick()
    {
        opanableWindow.SetActive(true);
    }
}
