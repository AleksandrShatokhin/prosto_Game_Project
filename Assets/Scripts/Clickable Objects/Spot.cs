using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour, IClickable
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PickableItem soda, vinegar;

    public void OnClick()
    {
        ClickToSpot();
    }

    private void ClickToSpot()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == soda && this.transform.GetChild((int)SpotEffects.Vinegar).gameObject.activeInHierarchy == true)
                {
                    this.transform.GetChild((int)SpotEffects.Vinegar).gameObject.SetActive(false);
                    this.transform.GetChild((int)SpotEffects.Foam).gameObject.SetActive(true);
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    StartCoroutine(DisableSpot());
                    return;
                }

                if (slot.ItemInSlot == vinegar && this.transform.GetChild((int)SpotEffects.Soda).gameObject.activeInHierarchy == true)
                {
                    this.transform.GetChild((int)SpotEffects.Soda).gameObject.SetActive(false);
                    this.transform.GetChild((int)SpotEffects.Foam).gameObject.SetActive(true);
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    StartCoroutine(DisableSpot());
                    return;
                }

                if (slot.ItemInSlot == soda)
                {
                    this.transform.GetChild((int)SpotEffects.Soda).gameObject.SetActive(true);
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return;
                }

                if (slot.ItemInSlot == vinegar)
                {
                    this.transform.GetChild((int)SpotEffects.Vinegar).gameObject.SetActive(true);
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return;
                }
            }
        }

        GameController.GetInstance().DisplayMessageOnScreen("Какое-то странное пятно. Возможно его нужно убрать!");
    }

    private IEnumerator DisableSpot(float delay = 0.05f)
    {
        Color spotColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        Color spotFoamColor = this.transform.GetChild((int)SpotEffects.Foam).GetComponent<SpriteRenderer>().color;

        while (spotColor.a > 0)
        {
            yield return new WaitForSeconds(delay);

            spotColor = new Color(1, 1, 1, spotColor.a - delay);
            spotFoamColor = new Color(1, 1, 1, spotFoamColor.a - delay);

            this.gameObject.GetComponent<SpriteRenderer>().color = spotColor;
            this.transform.GetChild((int)SpotEffects.Foam).GetComponent<SpriteRenderer>().color = spotFoamColor;
        }

        this.gameObject.SetActive(false);
    }
}

public enum SpotEffects
{
    Soda = 0,
    Vinegar = 1,
    Foam = 2
}