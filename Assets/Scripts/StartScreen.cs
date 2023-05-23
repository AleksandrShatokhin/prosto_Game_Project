using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button buttonStart, buttonExit;

    private void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = true;

        buttonStart.onClick.AddListener(StartGame);
        buttonExit.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Cutscene_1");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
