using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanogramController : MonoBehaviour, IPuzzle
{
    void IPuzzle.OnPuzzleStart()
    {
        //int maxValue = this.gameObject.transform.childCount;
        //int puzzleNumber = Random.Range(0, maxValue);
        //this.gameObject.transform.GetChild(puzzleNumber).gameObject.SetActive(true);

        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPuzzleEnd()
    {
        
    }

}
