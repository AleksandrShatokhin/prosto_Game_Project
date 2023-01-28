using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWindow : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        this.gameObject.SetActive(false);
    }
}
