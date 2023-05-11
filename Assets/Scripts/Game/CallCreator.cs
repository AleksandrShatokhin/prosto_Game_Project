using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallCreator : MonoBehaviour
{
    [SerializeField] GameObject phone, cityMap, houses;

    [SerializeField] private int minimumDelay, maximumDelay;
    private int numberHouse;
    [SerializeField] private MapStatus currentStatus;

    private void Start()
    {
        numberHouse = 0;
        currentStatus = MapStatus.Running;
        StartCoroutine(CreateCall());
    }

    private IEnumerator CreateCall()
    {
        while (true)
        {
            float delay = Random.Range(minimumDelay, maximumDelay);

            yield return new WaitForSeconds(delay);

            if (currentStatus == MapStatus.Running)
            {
                GenerateCall_Complete(numberHouse);
                ChangeNumberHouse();
            }
        }
    }

    private void ChangeNumberHouse() => numberHouse = (numberHouse < (houses.transform.childCount - 1)) ? numberHouse += 1 : numberHouse = 0;

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
