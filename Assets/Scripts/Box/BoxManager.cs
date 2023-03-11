using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    protected int sumOfClick;

    private void Start()
    {
        sumOfClick = 0;
    }

    public virtual void CounterSumOfClick(int value)
    {
        sumOfClick += value;
        Debug.Log(sumOfClick);
    }
}
