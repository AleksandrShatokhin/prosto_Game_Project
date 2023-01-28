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

    private DemonSO demonSO;

    public void OnStartMessageWindow(DemonSO demonSO, int numberMessage, int numberCitizen)
    {
        this.demonSO = demonSO;

        textMessage.text = this.demonSO.message[numberMessage];
        citizenImage.sprite = this.demonSO.citizenSprite[numberCitizen];
    }

    public void ClickComeBack()
    {
        GameController.GetInstance().SwitchWindow(cityMapWindow, this.gameObject);
    }

    public void ClickNextRoom()
    {
        GameController.GetInstance().SwitchWindow(demonRoom, this.gameObject);
        demonRoom.GetComponent<DemonRoom>().OnStartDemonRoom(this.demonSO);
        cityMapWindow.SetActive(false);
    }
}
