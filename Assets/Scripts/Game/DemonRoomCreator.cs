using UnityEngine;

public class DemonRoomCreator
{
    private DemonSO demonSO;
    private GameObject cityMapWindow;

    public DemonRoomCreator(DemonSO demonSO, GameObject cityMapWindow)
    {
        this.demonSO = demonSO;
        this.cityMapWindow = cityMapWindow;
    }

    public void CreateRoom()
    {
        GameObject demonRoom = GameObject.Instantiate(demonSO.demonRoomPrefab, demonSO.demonRoomPrefab.transform.position, Quaternion.identity) as GameObject;
        demonRoom.SetActive(true);
        demonRoom.GetComponent<IStartable>().OnStart(this.demonSO, this.cityMapWindow);
    }
}
