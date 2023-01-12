using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private GameObject prefabCityMap;

    public void ClickComeBack()
    {
        GameController.GetInstance().SwitchWindow(this.gameObject, prefabCityMap);
    }
}
