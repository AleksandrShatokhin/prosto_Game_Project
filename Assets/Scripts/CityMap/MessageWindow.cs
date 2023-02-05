using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    private const string textAccept = "Accept call", textCancel = "Cancel call";

    [SerializeField] private GameObject NextRoomButton;
    [SerializeField] private GameObject cityMapWindow;
    [SerializeField] private GameObject demonRoom;
    [SerializeField] private TextMeshProUGUI textButtonAccept;

    [SerializeField] private Image citizenImage;
    [SerializeField] private TextMeshProUGUI textMessage;

    private GameObject houseOnMap;

    private DemonSO demonSO;

    public void OnStartMessageWindow(DemonSO demonSO, int numberMessage, int numberCitizen, GameObject house)
    {
        this.demonSO = demonSO;
        this.houseOnMap = house;
        
        CheckIsCallAccept();

        textMessage.text = this.demonSO.message[numberMessage];
        citizenImage.sprite = this.demonSO.citizenSprite[numberCitizen];
    }

    private void CheckIsCallAccept()
    {
        bool isCallAccept = (houseOnMap.GetComponent<HouseOnCityMap>().GetCurrentSecond() == 1) ? true : false;

        if (isCallAccept)
        {
            NextRoomButton.SetActive(false);
            textButtonAccept.text = textAccept;
        }
        else
        {
            NextRoomButton.SetActive(true);
            textButtonAccept.text = textCancel;
        }
    }

    public void ClickComeBack()
    {
        GameController.GetInstance().SwitchWindow(cityMapWindow, this.gameObject);
        cityMapWindow.GetComponent<CityMap>().IsPause_Off();
    }

    public void ClickAccept()
    {
        bool isCallAccept = (houseOnMap.GetComponent<HouseOnCityMap>().GetCurrentSecond() == 0) ? true : false;

        if (!isCallAccept)
        {
            NextRoomButton.SetActive(true);
            houseOnMap.GetComponent<HouseOnCityMap>().SwitchHouseTimer(0);
            textButtonAccept.text = textCancel;
        }
        else
        {
            NextRoomButton.SetActive(false);
            houseOnMap.GetComponent<HouseOnCityMap>().SwitchHouseTimer(1);
            textButtonAccept.text = textAccept;
        }
    }

    public void ClickNextRoom()
    {
        GameController.GetInstance().GetCallCounter().AddToCounter();
        GameController.GetInstance().SwitchWindow(demonRoom, this.gameObject);
        demonRoom.GetComponent<DemonRoom>().OnStartDemonRoom(this.demonSO);
        ClickAccept();
        houseOnMap.SetActive(false);
        cityMapWindow.SetActive(false);
    }
}
