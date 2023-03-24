using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
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
