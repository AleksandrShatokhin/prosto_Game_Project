using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private Animator loadingCircleAnimator;

    private bool isPauseMode;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject tutorialBook;
    public TutorialBook GetTutorialBookComponent() => tutorialBook.GetComponent<TutorialBook>();

    // references to the main components
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MainUIController mainUIController;
    [SerializeField] private DemonInventory demonInventory;
    [SerializeField] private GameObject firstWindow;
    [SerializeField] private AudioSource _transitionAudioSource;

    public void AddDemonToCollection(DemonSO demon) => demonInventory.AddCaughtDemon(demon);

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1.0f;
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenDemonInventory();
        }
    }

    private void OpenDemonInventory()
    {
        if (demonInventory.gameObject.activeSelf)
        {
            demonInventory.gameObject.SetActive(false);
        }
        else
        {
            demonInventory.gameObject.SetActive(true);
        }
    }

    public void OpenTutorialBook()
    {
        if (tutorialBook.activeInHierarchy == true)
        {
            tutorialBook.SetActive(false);
            pauseWindow.SetActive(true);
        }
        else
        {
            tutorialBook.SetActive(true);
            pauseWindow.SetActive(false);
        }
    }

    public void SwitchWindow(GameObject toOpen, GameObject toClose, bool playAnimation = false, Sprite loadingCircleSprite = null)
    {
        if (playAnimation)
        {
            _transitionAudioSource.Play();
            StartCoroutine(SwitchWindowCour(toOpen, toClose, loadingCircleSprite));
        }
        else
        {
            toOpen.SetActive(true);
            toClose.SetActive(false);
        }
    }

    private IEnumerator SwitchWindowCour(GameObject toOpen, GameObject toClose, Sprite loadingCircleSprite)
    {
        if (loadingCircleSprite != null)
        {
            mainUIController.SetSpriteToLoadingCircle(loadingCircleSprite);
        }
        
        loadingCircleAnimator.SetTrigger("StartLoadingAnimTrigger");
        yield return new WaitForSeconds(1f);
        toOpen.SetActive(true);
        toClose.SetActive(false);
        loadingCircleAnimator.SetTrigger("FinishedLoadingTrigger");
    }

    public void DisplayMessageOnScreen(string message) => mainUIController.DispayMessageOnScreen(message);
    public void PlaySimpleAudio(AudioClip audio, float volume = 1.0f) => audioSource.PlayOneShot(audio, volume);
    public void StopSimpleAudio() => audioSource.Stop();

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