using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewspaperManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNewspaper;

    public void SetTextNewspaper(string text)
    {
        textNewspaper.text = text;
    }

    public void CloseWindowNewspaper()
    {
        this.gameObject.SetActive(false);
    }
}
