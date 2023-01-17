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
    [SerializeField] private int maximumCountCallsOnMap;

    private bool isPause;

    private void Start()
    {
        isPause = false;
        
        ClearMap();
        StartCoroutine(CallCreator());
    }

    void ClearMap()
    {
        foreach (Transform house in houses.transform)
        {
            house.gameObject.SetActive(false);
        }
    }

    private IEnumerator CallCreator()
    {
        while (true)
        {
            float delay = Random.Range(minimumDelay, maximumDelay);
            int numberHouse = Random.Range(0, houses.transform.childCount);

            yield return new WaitForSeconds(delay);

            if (!CheckStateHouse(numberHouse) && !isPause && CheckCountCallsOnMap())
            {
                houses.transform.GetChild(numberHouse).gameObject.SetActive(true);
                houses.transform.GetChild(numberHouse).GetComponent<HouseOnCityMap>().StartTimer(maximumTimeForLiveHouseOnMap, this);
            }
        }
    }

    private bool CheckStateHouse(int number)
    {
        bool canCall = (houses.transform.GetChild(number).gameObject.activeInHierarchy) ? true : false;
        return canCall;
    }

    private bool CheckCountCallsOnMap()
    {
        int counter = 0;

        foreach (Transform house in houses.transform)
        {
            if (house.gameObject.activeInHierarchy)
            {
                counter += 1;
            }
        }

        bool countCallsAcceptable = (counter < maximumCountCallsOnMap) ? true : false;
        return countCallsAcceptable;
    }

    public void ClickOnCall()
    {
        isPause = true;
        GameObject prefabMessage = Instantiate(prefabMessageWindow, prefabMessageWindow.transform.position, prefabMessageWindow.transform.rotation);
        prefabMessage.GetComponent<MessageWindow>().SetCityMap(this);
    }

    public bool IsPause() => isPause;
    public void IsPause_Off() => isPause = false;
}