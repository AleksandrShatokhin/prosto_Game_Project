using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperInRoom : MonoBehaviour, IClickable
{
    [SerializeField] GameObject newspaper;

    public void OnClick()
    {
        OpenNewspaper();
    }

    private void OpenNewspaper() => newspaper.SetActive(true);
}
