using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferToFinalyCutscene : CallsManager
{
    private const string nameCutScene = "Cutscene_2";

    public override void OpenMessageWindow()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameCutScene);
    }
}
