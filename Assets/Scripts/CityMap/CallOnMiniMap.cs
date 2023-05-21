using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallOnMiniMap : CallsManager
{
    private Button button;

    [SerializeField] private DemonSO demonSO;
    [SerializeField] private GameObject playerRoom;
    [SerializeField] private float differenceSize;
    

    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ClickCall);
    }

    public void ClickCall()
    {
        this.gameObject.SetActive(false);
        DemonRoomCreator demonRoomCreator = new DemonRoomCreator(this.demonSO, this.playerRoom);
        demonRoomCreator.CreateRoom();
    }

    public override void OpenMessageWindow()
    {
        GameObject messageWindow = Instantiate(this.demonSO.messageWindowPrefab, this.demonSO.messageWindowPrefab.transform.position, Quaternion.identity);
        messageWindow.GetComponent<IStartable>().OnStart(this.demonSO, this.gameObject);
    }

    public PlayerRoomUi GetPlayerRoomUI() => playerRoom.GetComponent<PlayerRoomUi>();

    //Special for EventTrigger on house
    public void ChangeSize_Plus(GameObject house)
    {
        house.transform.localScale = new Vector3(house.transform.localScale.x + differenceSize, house.transform.localScale.y + differenceSize, house.transform.localScale.z);
    }

    public void ChangeSize_Minus(GameObject house)
    {
        house.transform.localScale = new Vector3(house.transform.localScale.x - differenceSize, house.transform.localScale.y - differenceSize, house.transform.localScale.z);
    }
}
