using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private Animator loadingCircleAnimator;

    private bool isPauseMode;
    [SerializeField] GameObject pauseWindow;

    // references to the main components
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

    public void SwitchWindow(GameObject toOpen, GameObject toClose, bool playAnimation = false)
    {
        if (playAnimation)
        {
            StartCoroutine(SwitchWindowCour(toOpen, toClose));
        }
        else
        {
            toOpen.SetActive(true);
            toClose.SetActive(false);
        }
    }

    private IEnumerator SwitchWindowCour(GameObject toOpen, GameObject toClose)
    {
        loadingCircleAnimator.SetTrigger("StartLoadingAnimTrigger");
        yield return new WaitForSeconds(1f);
        toOpen.SetActive(true);
        toClose.SetActive(false);
        loadingCircleAnimator.SetTrigger("FinishedLoadingTrigger");
    }

    public void DisplayMessageOnScreen(string message) => mainUIController.DispayMessageOnScreen(message);

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

    public void ClosePanel(GameObject closeObject) => closeObject.SetActive(false);
}
