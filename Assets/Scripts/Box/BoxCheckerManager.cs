using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCheckerManager : MonoBehaviour
{
    public bool IsCorrect { get; private set; }
    protected void SetValueIsCorrectVariable(bool value) => IsCorrect = value;

    public virtual void StartCoroutineCheck() { }
    public virtual void StopCoroutineCheck() { }
}