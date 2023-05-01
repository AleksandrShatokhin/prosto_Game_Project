using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlesChecker : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject candles;

    public void OnClick()
    {
        CandleStatus candleStatus_0 = candles.transform.GetChild(0).GetComponent<Candle>().CurrentCandleStatus;
        CandleStatus candleStatus_1 = candles.transform.GetChild(1).GetComponent<Candle>().CurrentCandleStatus;
        CandleStatus candleStatus_2 = candles.transform.GetChild(2).GetComponent<Candle>().CurrentCandleStatus;
        CandleStatus candleStatus_3 = candles.transform.GetChild(3).GetComponent<Candle>().CurrentCandleStatus;
        CandleStatus candleStatus_4 = candles.transform.GetChild(4).GetComponent<Candle>().CurrentCandleStatus;

        if (candleStatus_0 == CandleStatus.Enabled && 
            candleStatus_1 == CandleStatus.Enabled && 
            candleStatus_2 == CandleStatus.Disabled && 
            candleStatus_3 == CandleStatus.Disabled && 
            candleStatus_4 == CandleStatus.Disabled)
        {
            GameController.GetInstance().DisplayMessageOnScreen("������ ���������� Number_1 !");
        }

        if (candleStatus_0 == CandleStatus.Disabled &&
            candleStatus_1 == CandleStatus.Disabled &&
            candleStatus_2 == CandleStatus.Enabled &&
            candleStatus_3 == CandleStatus.Disabled &&
            candleStatus_4 == CandleStatus.Enabled)
        {
            GameController.GetInstance().DisplayMessageOnScreen("������ ���������� Number_2 !");
        }
    }
}
