using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInDemonRoom : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject boxWindow;

    void IClickable.OnClick()
    {
        boxWindow.SetActive(true);
    }
}
