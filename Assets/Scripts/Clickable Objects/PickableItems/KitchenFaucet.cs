using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class KitchenFaucet : PickableItem
{
    [SerializeField] private ParticleSystem ps_Water;
    [SerializeField] private GameObject decanterWater;
    [SerializeField] private PickableItem decanterEmpty;
    [SerializeField] private bool isWaterActivate;
    [SerializeField] private AudioClip audioWater;

    public override void OnClick()
    {
        if (isWaterActivate == true)
        {
            FillDecanterWater();
        }
        else
        {
            SwitcherKitchenFaucet();
        }
    }

    private void SwitcherKitchenFaucet()
    {
        isWaterActivate = !isWaterActivate;

        if (isWaterActivate == true)
        {
            ps_Water.Play();
            GameController.GetInstance().PlaySimpleAudio(audioWater, 0.3f);
        }
        else
        {
            ps_Water.Stop();
            GameController.GetInstance().StopSimpleAudio();
        }
    }

    private void FillDecanterWater()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true && slot.ItemInSlot == decanterEmpty)
            {
                playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                slot.DeselectItem();
                decanterWater.GetComponent<IClickable>()?.OnClick();

                UIAudioManager.instance.PlayWaterToBottle(0.6f);
                return;
            }
            else
            {
                SwitcherKitchenFaucet();
            }
        }
    }

    private void OnDisable()
    {
        isWaterActivate = false;
        ps_Water.Stop();
        GameController.GetInstance().StopSimpleAudio();
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
