using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallOnMiniMap : MonoBehaviour
{
    private Button button;

    [SerializeField] private DemonSO demonSO;
    [SerializeField] private GameObject playerRoom;
    

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

    public void OpenMessageWindow()
    {
        GameObject messageWindow = Instantiate(this.demonSO.messageWindowPrefab, this.demonSO.messageWindowPrefab.transform.position, Quaternion.identity);
        messageWindow.GetComponent<IStartable>().OnStart(this.demonSO, this.gameObject);
    }

    public PlayerRoomUi GetPlayerRoomUI() => playerRoom.GetComponent<PlayerRoomUi>();
}
