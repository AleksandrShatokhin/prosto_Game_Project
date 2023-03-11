using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewspaperManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textNewspaper;

    public void OnStart(NewspaperSO newspaperSO)
    {
        textNewspaper.text = newspaperSO.Text.ToString();
    }

    public void CloseNewspaper()
    {
        this.gameObject.SetActive(false);
    }
}
