using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Symbol", menuName = "ScriptableObjects/SymbolSO", order = 2)]
public class SymbolSO : ScriptableObject
{
    // ������ �������� ��� ��������
    public List<string> Symbols;

    // ��������� ����������� �� ����� �� ������ �������� ��� ��������
    public int IndicatorSymbols;

    // ������ ������� ��� �������, �� ������� ������ ��������� ������
    public List<int> CallNumbers;
}