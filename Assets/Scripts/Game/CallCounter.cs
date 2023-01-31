using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCounter : MonoBehaviour
{
    [SerializeField] List<SymbolSO> symbols;
    private int counter;
    private int step = 1;

    private void Start()
    {
        counter = 0;

        foreach (SymbolSO symbol in symbols)
        {
            symbol.IndicatorSymbols = 0;
        }
    }

    public void AddToCounter() => counter += step;

    public void CheckCallCounter()
    {
        foreach (SymbolSO symbol in symbols)
        {
            CheckCurrentSymbol(symbol);
        }
    }

    private void CheckCurrentSymbol(SymbolSO symbol)
    {
        foreach (int variable in symbol.CallNumbers)
        {
            if (counter == variable)
            {
                Debug.Log(symbol.Symbols[symbol.IndicatorSymbols] + " has been created!");
                symbol.IndicatorSymbols += 1;
            }
        }
    }
}