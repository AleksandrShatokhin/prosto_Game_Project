using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Newspaper", menuName = "ScriptableObjects/NewspaperSO", order = 3)]
public class NewspaperSO : ScriptableObject
{
    public Sprite Sprite;

    public StatusNewspaper Status;

    public TextAsset Text;

    public int CallNumber;
}

public enum StatusNewspaper
{
    Data,
    NoData
}