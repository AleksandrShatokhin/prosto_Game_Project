using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private GameObject prefabCityMap;
    private CityMap cityMap;

    public void SetCityMap(CityMap cityMap) => this.cityMap = cityMap;

    public void ClickComeBack()
    {
        //GameController.GetInstance().SwitchWindow(this.gameObject, prefabCityMap);
        cityMap.IsPause_Off();
        Destroy(this.gameObject);
    }
}
