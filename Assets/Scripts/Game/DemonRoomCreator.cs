using UnityEngine;

public class DemonRoomCreator
{
    private DemonSO demonSO;
    private GameObject playerRoom;

    public DemonRoomCreator(DemonSO demonSO, GameObject playerRoom)
    {
        this.demonSO = demonSO;
        this.playerRoom = playerRoom;
    }

    public void CreateRoom()
    {
        GameObject demonRoom = GameObject.Instantiate(demonSO.demonRoomPrefab, demonSO.demonRoomPrefab.transform.position, Quaternion.identity) as GameObject;
        GameController.GetInstance().SwitchWindow(demonRoom, this.playerRoom, true, demonSO.loadingCircleToRoom);
        demonRoom.GetComponent<IStartable>().OnStart(this.demonSO, this.playerRoom);
    }
}
