using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellNanograms : MonoBehaviour
{
    [SerializeField] Sprite whiteSprite, blackSprite, markedSprite;

    [SerializeField] CellStatus status;
    [SerializeField] CellState cellState;
    private Button cellButton;

    [SerializeField] private int couter;

    private void Start()
    {
        cellButton = this.GetComponent<Button>();
        cellButton.onClick.AddListener(ClickCell);

        SetState_Closed();

        couter = 0;

        //if (status == CellStatus.Correct)
        //{
        //    SetState_Open();
        //}
    }

    private void ClickCell()
    {
        UIAudioManager.instance.PlayPencilNonogramPuzzle(0.3f);
        couter += 1;

        if (couter > 2)
        {
            couter = 0;
        }

        switch (couter)
        {
            case 0:
                SetState_Closed();
                break;
            case 1:
                SetState_Open();
                break;
            case 2:
                SetState_Marked();
                break;
        }
    }

    private void SetState_Open()
    {
        this.GetComponent<Image>().sprite = blackSprite;
        cellState = CellState.Open;
    }

    public void SetState_Closed()
    {
        this.GetComponent<Image>().sprite = whiteSprite;
        cellState = CellState.Closed;
    }

    public void SetState_Marked()
    {
        this.GetComponent<Image>().sprite = markedSprite;
        cellState = CellState.Marked;
    }

    public CellState GetState() => cellState;
    public CellStatus GetStatus() => status;
}

public enum CellState
{
    Open,
    Closed,
    Marked
}

public enum CellStatus
{
    Correct,
    Incorrect
}