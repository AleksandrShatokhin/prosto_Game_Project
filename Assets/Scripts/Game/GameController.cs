using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    private bool isPauseMode;
    [SerializeField] GameObject pauseWindow;

    // ссылки на основные компоненты
    [SerializeField] private GameObject firstWindow;
    [SerializeField] private MainUIController mainUIController;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        firstWindow.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMode();
        }
    }

    public void SwitchWindow(GameObject toOpen, GameObject toClose)
    {
        toOpen.SetActive(true);
        toClose.SetActive(false);
    }

    public MainUIController GetMainUIController() => mainUIController;

    public void PauseMode()
    {
        if (isPauseMode)
        {
            isPauseMode = false;
            pauseWindow.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            isPauseMode = true;
            pauseWindow.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
