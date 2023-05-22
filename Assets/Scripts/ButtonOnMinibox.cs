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
    [SerializeField] private Button buttonPanel;

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

        if (this.transform.GetChild(0).gameObject.activeInHierarchy == false)
        {
            GameController.GetInstance().DisplayMessageOnScreen("������� � ���� ����� �� ������� �����-�� ������� ���������!");
        }
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
        buttonPanel.interactable = false;
    }

    private IEnumerator CloseThisWindow()
    {
        yield return new WaitForSeconds(1.0f);
        minibox_Component.SwitchSpriteMinibox();
        handleHammer.SetActive(true);
        buttonPanel.interactable = true;
        this.transform.parent.gameObject.SetActive(false);
    }
}
