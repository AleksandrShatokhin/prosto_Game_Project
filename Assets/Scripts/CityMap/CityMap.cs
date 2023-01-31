using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CityMap : MonoBehaviour
{
    [SerializeField] private GameObject playerRoom;
    [SerializeField] private GameObject messageWindow;

    [SerializeField] private GameObject houses;
    [SerializeField] private int maximumTimeForLiveHouseOnMap;
    [SerializeField] private int minimumDelay, maximumDelay;
    [SerializeField] private int maximumCountCallsOnMap;

    [SerializeField] private bool isPause;

    private void Start()
    {
        isPause = false;
    }

    private void OnEnable()
    {
        isPause = false;
        StartCoroutine(CallCreator());
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

    public GameObject GetMessageWindow() => messageWindow;
    public int GetMaxTime() => maximumTimeForLiveHouseOnMap;
    public bool IsPause() => isPause;
    public void IsPause_On() => isPause = true;
    public void IsPause_Off() => isPause = false;

    public void ComeBackToPlayerRoom() => GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject);
}