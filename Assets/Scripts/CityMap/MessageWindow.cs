using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private GameObject cityMapWindow;
    [SerializeField] private GameObject demonRoom;

    [SerializeField] private Image citizenImage;
    [SerializeField] private TextMeshProUGUI textMessage;

    private GameObject houseOnMap;

    private DemonSO demonSO;

    public void OnStartMessageWindow(DemonSO demonSO, int numberMessage, int numberCitizen, GameObject house)
    {
        this.demonSO = demonSO;
        this.houseOnMap = house;

        textMessage.text = this.demonSO.message[numberMessage];
        citizenImage.sprite = this.demonSO.citizenSprite[numberCitizen];
    }

    public void ClickComeBack()
    {
        GameController.GetInstance().SwitchWindow(cityMapWindow, this.gameObject);
        cityMapWindow.GetComponent<CityMap>().IsPause_Off();
    }

    public void ClickNextRoom()
    {
        GameController.GetInstance().GetCallCounter().AddToCounter();
        GameController.GetInstance().SwitchWindow(demonRoom, this.gameObject);
        demonRoom.GetComponent<DemonRoom>().OnStartDemonRoom(this.demonSO);
        houseOnMap.SetActive(false);
        cityMapWindow.SetActive(false);
    }
}
