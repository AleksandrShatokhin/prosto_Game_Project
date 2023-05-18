using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//cups room
public class Box_2 : BoxManager
{
    [SerializeField] private GameObject toCloseWindow, toOpenWindow;
    [SerializeField] private List<BoxCheckerManager> checkers;

    private void Start()
    {
        buttonOpenBox.onClick.AddListener(ClickOpenBox);
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
    }

    public override void ClickOpenBox()
    {
        bool isCorrect = false;
        int countCorrect = 0;

        foreach (BoxCheckerManager checker in checkers)
        {
            if (checker.IsCorrect == true)
            {
                countCorrect += 1;
            }
        }

        isCorrect = (countCorrect == checkers.Count) ? true : false;

        if (isCorrect == true)
        {
            base.ClickOpenBox();
        }
        else
        {
            GameController.GetInstance().DisplayMessageOnScreen(messageBoxNotOpen);
        }
    }

    public void ClickButtonOnUpPanel()
    {
        GameController.GetInstance().SwitchWindow(this.toOpenWindow, this.toCloseWindow);
        UIAudioManager.instance.PlayPaperAudio(0.7f);
    }
}
