using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private GameObject prefabCityMap;
    [SerializeField] private GameObject prefabNextRoom;
    private CityMap cityMap;

    public void SetCityMap(CityMap cityMap) => this.cityMap = cityMap;

    public void ClickComeBack()
    {
        //GameController.GetInstance().SwitchWindow(this.gameObject, prefabCityMap);
        cityMap.IsPause_Off();
        Destroy(this.gameObject);
    }

    public void ClickNetRoom()
    {
        Destroy(cityMap.gameObject);
        Destroy(this.gameObject);
        Instantiate(prefabNextRoom, prefabNextRoom.transform.position, prefabNextRoom.transform.rotation);
    }
}
