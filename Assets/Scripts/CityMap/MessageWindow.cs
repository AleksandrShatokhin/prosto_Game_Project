using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour, IStartable
{
    private const string textAccept = "Принять", textNextRoom = "Отправиться";
    private const string textComeback = "На карту", textComehome = "Домой";

    private GameObject houseOnMap;
    [SerializeField] private GameObject cityMapWindow;
    [SerializeField] private GameObject playerRoom;

    [SerializeField] private TextMeshProUGUI textButtonAccept;
    [SerializeField] private TextMeshProUGUI textButtonCameback;

    [SerializeField] private Image citizenImage;
    [SerializeField] private TextMeshProUGUI textMessage;

    [SerializeField] private CallStatus currentStatus = CallStatus.Cancelled;

    private DemonSO demonSO;

    void IStartable.OnStart(DemonSO demonSO, GameObject houseOnMap)
    {
        this.demonSO = demonSO;
        this.houseOnMap = houseOnMap;

        CheckIsCallAccept();

        textMessage.text = this.demonSO.message;
        citizenImage.sprite = this.demonSO.citizenSprite;
    }

    private void CheckIsCallAccept()
    {
        if (currentStatus == CallStatus.Cancelled)
        {
            textButtonAccept.text = textAccept;
            textButtonCameback.text = textComeback;
        }
        else
        {
            textButtonAccept.text = textNextRoom;
            textButtonCameback.text = textComehome;
        }
    }

    public void ClickComeBack()
    {
        if (currentStatus == CallStatus.Cancelled)
        {
            GameController.GetInstance().SwitchWindow(cityMapWindow, this.gameObject);
            cityMapWindow.GetComponent<CityMap>().SetMapStatus_Running();
        }
        else
        {
            GameController.GetInstance().SwitchWindow(playerRoom, cityMapWindow);
        }
    }

    public void ClickAccept()
    {
        if (currentStatus == CallStatus.Cancelled)
        {
            currentStatus = CallStatus.Accepted;
            textButtonAccept.text = textNextRoom;
            textButtonCameback.text = textComehome;
        }
        else
        {
            GoToTheDemonRoom();
        }
    }

    public void GoToTheDemonRoom()
    {
        GameController.GetInstance().GetCallCounter().AddToCounter();
        DemonRoomCreator creator = new DemonRoomCreator(demonSO, cityMapWindow);
        creator.CreateRoom();
        ResetVariables();
    }

    private void ResetVariables()
    {
        currentStatus = CallStatus.Cancelled;
        houseOnMap.SetActive(false);
        this.gameObject.SetActive(false);
        cityMapWindow.SetActive(false);
    }
}