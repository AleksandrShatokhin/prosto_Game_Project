using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabyrinthCheckpoint : MonoBehaviour
{
    public void ActivateCheckpoint()
    {
        GetComponent<TMP_Text>().color = Color.blue;
    }

    public void DeactivateCheckpoint()
    {
        GetComponent<TMP_Text>().color = Color.white;
    }
}
