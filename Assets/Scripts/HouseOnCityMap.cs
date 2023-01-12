using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOnCityMap : MonoBehaviour
{
    private int timer = 0;
    private int second = 1;

    public void StartTimer(int maxTime)
    {
        StartCoroutine(Timer(maxTime));
    }

    private IEnumerator Timer(int maxTime)
    {
        while (true)
        {
            if (timer == 5)
            {
                this.gameObject.SetActive(false);
                timer = 0;
            }

            timer += second;
            yield return new WaitForSeconds(second);
        }
    }
}