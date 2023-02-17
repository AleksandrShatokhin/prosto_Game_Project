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

    [SerializeField] private MapStatus currentStatus;

    private void Start()
    {
        currentStatus = MapStatus.Running;
    }

    private void OnEnable()
    {
        StartCoroutine(CallCreator());
    }

    private IEnumerator CallCreator()
    {
        while (true)
        {
            float delay = Random.Range(minimumDelay, maximumDelay);
            int numberHouse = Random.Range(0, houses.transform.childCount);

            yield return new WaitForSeconds(delay);

            if (!CheckStateHouse(numberHouse) && currentStatus == MapStatus.Running && CheckCountCallsOnMap())
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
    public void SetMapStatus_Running() => currentStatus = MapStatus.Running;
    public void SetMapStatus_Stopped() => currentStatus = MapStatus.Stopped;

    // ввызывается по событию на кнопке в редакторе
    public void ComebackToPlayerRoom() => GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject);
}