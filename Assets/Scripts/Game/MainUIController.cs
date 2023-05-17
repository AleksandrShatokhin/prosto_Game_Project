using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    private Animator anim_MainUI;

    [SerializeField] private TextMeshProUGUI textMessage;
    [SerializeField] private Image sr_Circle;

    private void Start()
    {
        anim_MainUI = GetComponent<Animator>();
    }

    public void DispayMessageOnScreen(string message)
    {
        anim_MainUI.SetTrigger("isDisplayMessage");
        textMessage.text = message;
    }

    public void SetSpriteToLoadingCircle(Sprite sprite) => sr_Circle.sprite = sprite;
}
