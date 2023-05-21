using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene_2_Manager : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;

    public void LoadStartScene()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("StartScreen");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadStartScene();
        }
    }
}
