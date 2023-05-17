using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DemonInventory : MonoBehaviour
{
    [SerializeField] private List<DemonInventorySlot> demonSlots;
    [SerializeField] private List<DemonSO> caughtDemons;

    [SerializeField] private Image demonImage;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TMP_Text demonDescription;

    private void OnEnable()
    {
        for (int i = 0; i < caughtDemons.Count; i++)
        {
            demonSlots[i].demonSO = caughtDemons[i];
            demonSlots[i].GetComponent<Toggle>().interactable = true;
            demonSlots[i].ConfigureSlot();
        }
    }

    public void ChangeCurrentDemon(DemonSO chosenDemonSO)
    {
        SetDemonInventorySprite(chosenDemonSO);
        dialogText.text = chosenDemonSO.dialogText;
        dialogText.gameObject.SetActive(false);
        demonDescription.text = chosenDemonSO.demonName;
    }

    private void SetDemonInventorySprite(DemonSO chosenDemonSO)
    {
        demonImage.gameObject.SetActive(true);
        demonImage.sprite = chosenDemonSO.demonSprite;
        demonImage.SetNativeSize();
        Vector3 newScale = new Vector3(1, 1, 1);
        newScale *= 0.5f;
        demonImage.rectTransform.localScale = newScale;
    }

    public void AddCaughtDemon(DemonSO caughtDemon)
    {
        if (!caughtDemons.Contains(caughtDemon))
        {
            caughtDemons.Add(caughtDemon);
        }
    }

    public void OnTalkToDemonButtonPressed()
    {
        dialogText.gameObject.SetActive(true);
    }

    public void OnCloseDemonInventoryButtonPressed()
    {
        gameObject.SetActive(false);
    }
}