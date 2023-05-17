using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button buttonStart, buttonExit;

    private void Start()
    {
        buttonStart.onClick.AddListener(StartGame);
        buttonExit.onClick.AddListener(ExitGame);

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        AudioClip clip = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Sound/Music/Menu.mp3", typeof(AudioClip));
        audioSource.clip = clip;
        audioSource.Play();
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
