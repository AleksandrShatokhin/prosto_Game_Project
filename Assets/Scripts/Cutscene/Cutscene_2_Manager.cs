using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene_2_Manager : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void LoadStartScene()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("Titles");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadStartScene();
        }
    }
}
