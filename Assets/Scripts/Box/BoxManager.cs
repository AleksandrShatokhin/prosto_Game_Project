using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    // Parameters for output a message on the screen
    protected const string messageEmptyButton = "Чего-то не хватает!";
    protected const string messageEmptySlider = "Чего-то не хватает!";
    protected const string messageBoxNotOpen = "Не удалось открыть шкатулку. Возможно что-то сделано неверно!";

    // Parameters for interaction with the box
    [SerializeField] protected Button buttonLeft, buttonRight, buttonOpenBox;

    protected void ClickButtonLeft() => this.gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
    protected void ClickButtonRight() => this.gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);

    public virtual void ClickOpenBox()
    {
        GameObject boxWindow = this.transform.parent.gameObject;
        boxWindow.transform.rotation = Quaternion.Euler(-45.0f, -45.0f, 45.0f);
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        buttonOpenBox.gameObject.SetActive(false);
    }

    public virtual void SetClickOnButton(ButtonColor value)
    {
        
    }

    public virtual void CloseBox()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
