using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NanogramsMain : MonoBehaviour
{
    [SerializeField] private GameObject demonRoom;
    [SerializeField] private Button buttonCheck, buttonReset;
    [SerializeField] private GameObject gameGrid;
    [SerializeField] private int countToWin;

    private void Start()
    {
        buttonCheck.onClick.AddListener(ClickCheck);
        buttonReset.onClick.AddListener(ClickReset);
    }

    private void ClickCheck()
    {
        int correctCells = 0;
        int incorrectCells = 0;

        foreach (Transform cell in gameGrid.transform)
        {
            if (cell.GetComponent<CellNanograms>().GetStatus() == CellStatus.Correct && cell.GetComponent<CellNanograms>().GetState() == CellState.Open)
            {
                correctCells += 1;
            }

            if (cell.GetComponent<CellNanograms>().GetStatus() == CellStatus.Incorrect && cell.GetComponent<CellNanograms>().GetState() == CellState.Open)
            {
                incorrectCells += 1;
            }
        }

        bool isWin = (correctCells == countToWin && incorrectCells == 0) ? true : false;

        if (isWin == true)
        {
            Debug.Log("Success!");
            demonRoom.GetComponent<DemonRoom>().ClickComeBack();
        }
        else
        {
            Debug.Log("Failure!");
        }

        Debug.Log("Corrent cells: " + correctCells + " / Incorrect cells: " + incorrectCells);
    }

    private void ClickReset()
    {
        foreach (Transform cell in gameGrid.transform)
        {
            cell.GetComponent<CellNanograms>().SetState_Closed();
        }
    }
}
