using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CityMap : MonoBehaviour
{
    [SerializeField] private GameObject prefabMessageWindow;

    [SerializeField] private GameObject houses;
    [SerializeField] private int maximumTimeForLiveHouseOnMap;
    [SerializeField] private int minimumDelay, maximumDelay;

    private void Start()
    {
        foreach (Transform house in houses.transform)
        {
            house.gameObject.SetActive(false);
        }

        StartCoroutine(CallCreator());
    }

    private IEnumerator CallCreator()
    {
        while (true)
        {
            float delay = Random.Range(minimumDelay, maximumDelay);
            int numberHouse = Random.Range(0, houses.transform.childCount);

            yield return new WaitForSeconds(delay);

            if (!CheckStateHouse(numberHouse))
            {
                houses.transform.GetChild(numberHouse).gameObject.SetActive(true);
                houses.transform.GetChild(numberHouse).GetComponent<HouseOnCityMap>().StartTimer(maximumTimeForLiveHouseOnMap);
            }
        }
    }

    private bool CheckStateHouse(int number)
    {
        bool canCall = (houses.transform.GetChild(number).gameObject.activeInHierarchy) ? true : false;
        return canCall;
    }

    public void ClickOnHouse()
    {
        GameController.GetInstance().SwitchWindow(this.gameObject, prefabMessageWindow);
    }
}