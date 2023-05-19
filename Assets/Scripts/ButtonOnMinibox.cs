using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnMinibox : MonoBehaviour
{
    // Work with inventory
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private ButtonsWithSymbolToMinibox buttonsWithSymbol_Component;

    // Work with click result
    [SerializeField] private Minibox minibox_Component;
    [SerializeField] private GameObject handleHammer;

    public void ClickButton()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == buttonsWithSymbol_Component)
                {
                    AddButtonFromInventoryToLockImage(slot);
                    return;
                }
            }
        }

        GameController.GetInstance().DisplayMessageOnScreen("Кажется в этом замке не зватает каких-то круглых элементов!");
    }

    private void AddButtonFromInventoryToLockImage(InventoryItemSlot slot)
    {
        foreach (Transform image in this.gameObject.transform)
        {
            image.gameObject.SetActive(true);
        }

        playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
        slot.DeselectItem();
        UIAudioManager.instance.PlayClickAudio();

        StartCoroutine(CloseThisWindow());
    }

    private IEnumerator CloseThisWindow()
    {
        yield return new WaitForSeconds(1.0f);
        minibox_Component.SwitchSpriteMinibox();
        handleHammer.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
