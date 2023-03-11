using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnSelectButton(GameObject cross)
    {
        cross.SetActive(true);
    }

    public void OnDeselectButton(GameObject cross)
    {
        cross.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
