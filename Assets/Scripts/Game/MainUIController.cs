using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    private const string textZero = "";
    private Animator anim_MainUI;

    [SerializeField] private TextMeshProUGUI textMessage;
    [SerializeField] private Image sr_Circle;
    [SerializeField] private int maxSecondMessageOnScreen;

    private void Start()
    {
        anim_MainUI = GetComponent<Animator>();
        SetTextParametrs(textZero, false);
    }

    public void DispayMessageOnScreen(string message)
    {
        if (textMessage.gameObject.activeInHierarchy == false)
        {
            StartCoroutine(TimerToDisplayMessage(message));
        }
        else
        {
            StopAllCoroutines();
            textMessage.text = "";
            StartCoroutine(TimerToDisplayMessage(message));
        }
    }

    public IEnumerator TimerToDisplayMessage(string message)
    {
        int counter = 0;

        SetTextParametrs(message, true);

        while (counter < maxSecondMessageOnScreen)
        {
            counter += 1;
            yield return new WaitForSeconds(1.0f);
        }

        SetTextParametrs(textZero, false);
    }

    private void SetTextParametrs(string text, bool isActiveInScene)
    {
        textMessage.text = text;
        textMessage.gameObject.SetActive(isActiveInScene);
    }

    public void SetSpriteToLoadingCircle(Sprite sprite) => sr_Circle.sprite = sprite;
}
