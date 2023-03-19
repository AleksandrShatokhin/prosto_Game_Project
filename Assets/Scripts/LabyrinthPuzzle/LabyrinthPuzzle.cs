using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthPuzzle : MonoBehaviour, IPuzzle
{
    [SerializeField] private GameObject demonRoom;
    [SerializeField] private LabyrinthCircle labyrinthCircle;


    public void OnRestartFromCheckpointButtonPressed()
    {
        labyrinthCircle.RestartFromCheckpoint();
    }

    public void OnRestartFromThebeginningButtonPressed()
    {
        labyrinthCircle.RestartFromCheckpoint(true);
    }

    public void OnPuzzleEnd()
    {
        demonRoom.GetComponent<DemonRoom>().ClickComeBack();
    }

    public void OnPuzzleStart()
    {
    }
}
