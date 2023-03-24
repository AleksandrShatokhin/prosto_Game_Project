using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [SerializeField] protected Button buttonLeft, buttonRight, buttonOpenBox;

    protected void ClickButtonLeft() => this.gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
    protected void ClickButtonRight() => this.gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);

    public virtual void ClickOpenBox()
    {
        GameObject boxWindow = this.transform.parent.gameObject;
        boxWindow.transform.rotation = Quaternion.Euler(-45.0f, -45.0f, 45.0f);
    }

    public virtual void SetClickOnButton(ButtonColor value)
    {
        
    }

    public virtual void CloseBox()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
