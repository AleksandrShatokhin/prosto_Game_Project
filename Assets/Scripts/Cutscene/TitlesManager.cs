using UnityEngine;

public class TitlesManager : MonoBehaviour
{
    private const string nameStartScene = "StartScreen";
    [SerializeField] private GameObject loadingPanel;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void LoadStartScene()
    {
        loadingPanel.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameStartScene);
    }
}
