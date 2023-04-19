using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInAttic : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject opanableObject;

    public void OnClick()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        opanableObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
