using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Symbol", menuName = "ScriptableObjects/SymbolSO", order = 2)]
public class SymbolSO : ScriptableObject
{
    // ������ �������� ��� ��������
    public List<Sprite> Sprites;

    // ��������� ����������� �� ����� �� ������ �������� ��� ��������
    public int IndicatorSymbols;

    // ������ ������� ��� �������, �� ������� ������ ��������� ������
    public List<int> CallNumbers;
}