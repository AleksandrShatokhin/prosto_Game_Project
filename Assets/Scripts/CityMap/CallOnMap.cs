using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallOnMap : MonoBehaviour
{
    private Button buttonToNextRoom;
    [SerializeField] DemonSO demonSO;
    [SerializeField] GameObject messageWindow, cityMap;

    private void Start()
    {
        buttonToNextRoom = this.GetComponent<Button>();
        buttonToNextRoom.onClick.AddListener(OpenMessageWindow);
    }

    public void OpenMessageWindow()
    {
        if (messageWindow.GetComponent<MessageWindow>().GetCurrentStatus() == CallStatus.Accepted)
        {
            GoToTheDemonRoom();
        }
        else
        {
            messageWindow.SetActive(true);
            messageWindow.GetComponent<IStartable>().OnStart(this.demonSO, this.gameObject);
        }
    }

    public void GoToTheDemonRoom()
    {
        DemonRoomCreator creator = new DemonRoomCreator(demonSO, cityMap);
        creator.CreateRoom();
        ResetVariables();
    }

    private void ResetVariables()
    {
        messageWindow.GetComponent<MessageWindow>().SetCurrentStatus(CallStatus.Cancelled);
        this.gameObject.SetActive(false);
        cityMap.SetActive(false);
    }
}