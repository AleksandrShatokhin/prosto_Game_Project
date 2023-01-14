using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Demon", menuName = "ScriptableObjects/DemonSO", order = 1)]
public class DemonSO : ScriptableObject
{
    public Sprite demonSprite;
    public List<Items> neededItems;
}

public enum Items
{
    HolyWater,
    Cross,
    Garlic

}