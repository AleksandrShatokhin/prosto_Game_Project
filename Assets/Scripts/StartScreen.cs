using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button buttonStart, buttonExit;

    private void Start()
    {
        buttonStart.onClick.AddListener(StartGame);
        buttonExit.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
