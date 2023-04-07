using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IClickable
{
    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] private GameObject shadow;
    [SerializeField] private Checker checkerComponent;

    private CandleStatus currentCandleStatus;

    private void Start()
    {
        ExtinguishCandle();
    }

    void IClickable.OnClick()
    {
        CandleStatusHandler();
    }

    private void CandleStatusHandler() => currentCandleStatus = (currentCandleStatus == CandleStatus.Disabled) ? LigthCandle() : ExtinguishCandle();

    private CandleStatus LigthCandle()
    {
        //shadow.SetActive(true);
        ps_Flame.Play();
        checkerComponent.SetSprite(shadow.GetComponent<SpriteRenderer>().sprite);
        return currentCandleStatus = CandleStatus.Enabled;
    }

    private CandleStatus ExtinguishCandle()
    {
        //shadow.SetActive(false);
        ps_Flame.Stop();
        checkerComponent.RemoveSprite(shadow.GetComponent<SpriteRenderer>().sprite);
        return currentCandleStatus = CandleStatus.Disabled;
    }
}

public enum CandleStatus
{
    Enabled,
    Disabled
}