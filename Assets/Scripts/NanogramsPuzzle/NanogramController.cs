using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanogramController : MonoBehaviour, IPuzzle
{
    private int puzzleNumber;

    void IPuzzle.OnPuzzleStart()
    {
        int maxValue = this.gameObject.transform.childCount;
        puzzleNumber = Random.Range(0, maxValue);
        this.gameObject.transform.GetChild(puzzleNumber).gameObject.SetActive(true);
    }

    public void OnPuzzleEnd()
    {
        
    }

}
