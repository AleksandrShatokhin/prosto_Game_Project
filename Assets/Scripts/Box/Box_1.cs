using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Box_1 : MonoBehaviour
{
    [SerializeField] Button buttonLeft, buttonRight, buttonOpenBox;

    [SerializeField] Slider slider;
    [SerializeField] Button button_N1, button_N2, button_N3;

    private int sumOfClick;

    void Start()
    {
        buttonLeft.onClick.AddListener(ClickButtonLeft);
        buttonRight.onClick.AddListener(ClickButtonRight);
        buttonOpenBox.onClick.AddListener(ClickOpenBox);
    }

    private void ClickButtonLeft()
    {
        this.gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
    }

    private void ClickButtonRight()
    {
        this.gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);
    }

    private void ClickOpenBox()
    {
        if (slider.value == 1 && sumOfClick == 6)
        {
            Debug.Log("Box is open!");
        }
        else
        {
            sumOfClick = 0;
            Debug.Log("Box is not open!");
        }
    }

    // Вызываю на кнопках через Event
    public void ClickButtonOnBackPanel(TextMeshProUGUI text)
    {
        sumOfClick = sumOfClick + int.Parse(text.text);
        Debug.Log(sumOfClick);
    }

    public void ClickToCloseBox(GameObject roomCanvas)
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        roomCanvas.SetActive(true);
    }
}
