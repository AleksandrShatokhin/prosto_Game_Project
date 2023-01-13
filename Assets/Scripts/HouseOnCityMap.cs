using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HouseOnCityMap : MonoBehaviour
{
    private CityMap cityMap;

    private int timer = 0;
    private int second = 1;

    public void StartTimer(int maxTime, CityMap cityMap)
    {
        this.cityMap = cityMap;
        StartCoroutine(Timer(maxTime));
    }

    private IEnumerator Timer(int maxTime)
    {
        while (true)
        {
            if (timer == maxTime)
            {
                this.gameObject.SetActive(false);
                timer = 0;
            }

            if (!this.cityMap.IsPause())
            {
                timer += second;
            }
            
            yield return new WaitForSeconds(second);
        }
    }
}