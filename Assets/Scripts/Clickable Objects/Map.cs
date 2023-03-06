using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject characterRoom;
    public void OnClick()
    {
        GameController.GetInstance().SwitchWindow(cityMap, characterRoom);
    }
}
