using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Symbol", menuName = "ScriptableObjects/SymbolSO", order = 2)]
public class SymbolSO : ScriptableObject
{
    // список символов для создания
    public List<Sprite> Sprites;

    // индикатор указывающий на номер из списка символов для создания
    public int IndicatorSymbols;

    // список номеров тех вызовов, на которых должен появиться символ
    public List<int> CallNumbers;
}