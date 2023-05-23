using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Catscene_1_Manager : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void LoadMainScene()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("MainScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadMainScene();
        }    
    }
}
