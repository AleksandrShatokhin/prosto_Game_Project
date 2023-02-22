using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellNanograms : MonoBehaviour
{
    [SerializeField] CellStatus status;
    [SerializeField] CellState cellState;
    private Button cellButton;

    private void Start()
    {
        cellButton = this.GetComponent<Button>();
        cellButton.onClick.AddListener(ClickCell);

        SetState_Closed();
    }

    private void ClickCell()
    {
        if (this.cellState == CellState.Open)
        {
            SetState_Closed();
        }
        else
        {
            SetState_Open();
        }
    }

    private void SetState_Open()
    {
        this.GetComponent<Image>().color = Color.black;
        cellState = CellState.Open;
    }

    public void SetState_Closed()
    {
        this.GetComponent<Image>().color = Color.white;
        cellState = CellState.Closed;
    }

    public CellState GetState() => cellState;
    public CellStatus GetStatus() => status;
}

public enum CellState
{
    Open,
    Closed
}

public enum CellStatus
{
    Correct,
    Incorrect
}