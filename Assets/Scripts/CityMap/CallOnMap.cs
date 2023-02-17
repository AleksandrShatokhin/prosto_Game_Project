using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallOnMap : MonoBehaviour
{
    private Button buttonToNextRoom;
    [SerializeField] DemonSO demonSO;

    private void Start()
    {
        buttonToNextRoom = this.GetComponent<Button>();
        buttonToNextRoom.onClick.AddListener(OpenMessageWindow);
    }

    private void OpenMessageWindow()
    {
        CityMap cityMap = this.transform.GetComponentInParent<CityMap>();
        GameObject messageWindow = cityMap.GetMessageWindow();

        cityMap.SetMapStatus_Stopped();
        messageWindow.SetActive(true);
        messageWindow.GetComponent<IStartable>().OnStart(this.demonSO, this.gameObject);
    }
}