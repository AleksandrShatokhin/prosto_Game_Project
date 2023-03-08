using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour, IStartable
{
    private const string textAccept = "Принять";
    private const string textCancel = "Отказать";

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

        textButtonAccept.text = textAccept;
        textButtonCameback.text = textCancel;

        textMessage.text = this.demonSO.message.ToString();
        citizenImage.sprite = this.demonSO.citizenSprite;
    }

    public void ClickAccept()
    {
        SetCurrentStatus(CallStatus.Accepted);
        GameController.GetInstance().GetComponent<CallCreator>().GenerateCall_Off();
        cityMapWindow.SetActive(false);
        GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject);
    }

    public void ClickCancel()
    {
        cityMapWindow.GetComponent<CityMapManager>().DeleteCall();
        cityMapWindow.SetActive(false);
        GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject);
    }

    public CallStatus GetCurrentStatus() => currentStatus;
    public void SetCurrentStatus(CallStatus value) => currentStatus = value;
}