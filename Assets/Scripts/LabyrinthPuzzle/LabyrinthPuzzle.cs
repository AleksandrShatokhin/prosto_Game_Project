using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthPuzzle : MonoBehaviour, IPuzzle
{
    [SerializeField] private GameObject demonRoom;
    [SerializeField] private LabyrinthCircle labyrinthCircle;
    [SerializeField] private GameObject labyrinthObject;


    public void OnRestartFromCheckpointButtonPressed()
    {
        labyrinthCircle.RestartFromCheckpoint();
    }

    public void OnRestartFromThebeginningButtonPressed()
    {
        labyrinthObject.gameObject.transform.rotation = Quaternion.identity;
        labyrinthCircle.RestartFromCheckpoint(true);
    }

    public void OnPuzzleEnd()
    {
        //GameController.GetInstance().AddDemonToCollection(demonRoom.GetComponent<DemonRoom>().GetCurrentDemonSO);
        //demonRoom.GetComponent<DemonRoom>().ClickComeBack();
        demonRoom.GetComponent<IFinaly>().CuptureAnimationOpen();
    }

    public void OnPuzzleStart()
    {
    }
}
