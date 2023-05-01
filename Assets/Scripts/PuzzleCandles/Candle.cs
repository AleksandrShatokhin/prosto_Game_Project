using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IClickable
{
    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] private GameObject shadow;
    [SerializeField] private Checker checkerComponent;
    public CandleStatus CurrentCandleStatus { get; private set; }

    private void Start()
    {
        ExtinguishCandle();
    }

    void IClickable.OnClick()
    {
        if (this.GetComponent<SpriteRenderer>().enabled == false)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            return;
        }

        CandleStatusHandler();
    }

    private void CandleStatusHandler() => CurrentCandleStatus = (CurrentCandleStatus == CandleStatus.Disabled) ? LigthCandle() : ExtinguishCandle();

    private CandleStatus LigthCandle()
    {
        shadow.SetActive(true);
        ps_Flame.Play();
        return CurrentCandleStatus = CandleStatus.Enabled;
    }

    public CandleStatus ExtinguishCandle()
    {
        shadow.SetActive(false);
        ps_Flame.Stop();
        return CurrentCandleStatus = CandleStatus.Disabled;
    }

    public Sprite GetShadowSprite() => shadow.GetComponent<SpriteRenderer>().sprite;
}

public enum CandleStatus
{
    Enabled,
    Disabled
}