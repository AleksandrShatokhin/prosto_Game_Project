using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallCreator : MonoBehaviour
{
    [SerializeField] GameObject phone, cityMap, houses;

    private Color defaultColor;

    [SerializeField] private int minimumDelay, maximumDelay;
    [SerializeField] private MapStatus currentStatus;

    private void Start()
    {
        defaultColor = phone.GetComponent<Image>().color;
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
                currentStatus = MapStatus.Stopped;
                phone.GetComponent<PhoneInPlayerRoom>().CallCame(numberHouse);
            }
        }
    }

    public void GenerateCall_On()
    {
        phone.SetActive(true);
        currentStatus = MapStatus.Running;
        phone.GetComponent<Image>().color = defaultColor;
    }

    public bool IsCallCreated()
    {
        bool callCreater = (currentStatus == MapStatus.Running) ? true : false;
        return callCreater;
    }
}
