using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IClickable
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PickableItem pickupCandle;

    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] private GameObject shadow;
    public CandleStatus CurrentCandleStatus { get; private set; }

    private void Start()
    {
        ExtinguishCandle();
    }

    void IClickable.OnClick()
    {
        if (this.GetComponent<SpriteRenderer>().enabled == false)
        {
            AddCandleOnTable();
            return;
        }

        CandleStatusHandler();
    }

    private void AddCandleOnTable()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == pickupCandle)
                {
                    this.GetComponent<SpriteRenderer>().enabled = true;
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    this.gameObject.layer = (int)Layers.Pickable;
                    return;
                }
            }
        }

        GameController.GetInstance().DisplayMessageOnScreen("Кажется тут не хватает одной свечки!?");
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