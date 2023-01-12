using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    public void SwitchWindow(GameObject currentWindow, GameObject newWindow)
    {
        Destroy(currentWindow);
        Instantiate(newWindow, newWindow.transform.position, newWindow.transform.rotation);
    }
}
