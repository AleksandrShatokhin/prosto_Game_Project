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
    
    private int currentStepToHint;
    private Color colorHint = new Color(190, 255, 190, 255);

    private void Start()
    {
        buttonCheck.onClick.AddListener(ClickCheck);
        buttonReset.onClick.AddListener(ClickReset);

        currentStepToHint = 0;
    }

    private void ClickCheck()
    {
        UIAudioManager.instance.PlayClickSoftAudio(0.6f);
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
            demonRoom.GetComponent<IFinaly>().CuptureAnimationOpen();
        }
        else
        {
            ActivateHintOnCorrectCells(correctCells, incorrectCells);
        }
    }

    private void ActivateHintOnCorrectCells(int correctCells, int incorrectCells)
    {
        currentStepToHint += 1;

        if (currentStepToHint == 1)
        {
            foreach (Transform cell in gameGrid.transform)
            {
                if (cell.GetComponent<CellNanograms>().GetStatus() == CellStatus.Correct)
                {
                    StartCoroutine(SwitchColor(cell.gameObject));
                }
            }

            currentStepToHint = 0;
        }
        else
        {
            GameController.GetInstance().DisplayMessageOnScreen("Правильных: " + correctCells + " / Неправильных: " + incorrectCells);
        }
    }

    private IEnumerator SwitchColor(GameObject cell)
    {
        Color defaultColor = cell.GetComponent<Image>().color;

        cell.GetComponent<Button>().interactable = false;
        cell.GetComponent<Image>().color = colorHint;

        yield return new WaitForSeconds(1.5f);

        cell.GetComponent<Button>().interactable = true;
        cell.GetComponent<Image>().color = defaultColor;
    }

    private void ClickReset()
    {
        UIAudioManager.instance.PlayClickSoftAudio(0.6f);

        foreach (Transform cell in gameGrid.transform)
        {
            cell.GetComponent<CellNanograms>().SetState_Closed(true);
        }
    }
}
