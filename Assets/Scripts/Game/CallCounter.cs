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

    public Sprite GetSymbolSprite()
    {
        Sprite currentSymbol = null;

        foreach (SymbolSO symbol in symbols)
        {
            foreach (int variable in symbol.CallNumbers)
            {
                if (counter == variable)
                {
                    currentSymbol = symbol.Sprites[symbol.IndicatorSymbols];
                    symbol.IndicatorSymbols += 1;
                }
            }
        }

        return currentSymbol;
    }
}