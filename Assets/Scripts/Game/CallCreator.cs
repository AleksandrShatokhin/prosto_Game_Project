using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallCreator : MonoBehaviour
{
    [SerializeField] GameObject phone, cityMap, houses;

    [SerializeField] private int minimumDelay, maximumDelay;
    [SerializeField] private MapStatus currentStatus;

    private void Start()
    {
        currentStatus = MapStatus.Running;
        StartCoroutine(CreateCall());
    }

    private IEnumerator CreateCall()
    {
        while (true)
        {
            int numberHouse = Random.Range(0, houses.transform.childCount);
            float delay = Random.Range(minimumDelay, maximumDelay);

            yield return new WaitForSeconds(delay);

            if (currentStatus == MapStatus.Running)
            {
                GenerateCall_Complete(numberHouse);
            }
        }
    }

    private void GenerateCall_Complete(int numberHouse)
    {
        currentStatus = MapStatus.Stopped;
        phone.GetComponent<PhoneInPlayerRoom>().CallCame(numberHouse);
    }

    public void GenerateCall_Off()
    {
        currentStatus = MapStatus.Stopped;
        phone.GetComponent<PhoneInPlayerRoom>().CallStatus_Accept();
    }

    public void GenerateCall_On()
    {
        currentStatus = MapStatus.Running;
        phone.GetComponent<PhoneInPlayerRoom>().CallStatus_NotAccept();
    }

    public bool IsCallCreated()
    {
        bool isCallCreated = (currentStatus == MapStatus.Running) ? true : false;
        return isCallCreated;
    }
}
