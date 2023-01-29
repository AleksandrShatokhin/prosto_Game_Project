using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text textObject;

    public void OnCloseWindowButtonPressed()
    {
        Destroy(this.gameObject);
    }


    public void SetWindowText(string textToSet)
    {
        textObject.text = textToSet;
    }
}
