using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class DemonInventory : MonoBehaviour
{
    [SerializeField] private List<DemonInventorySlot> demonSlots;
    [SerializeField] public List<DemonSO> caughtDemons;
    [SerializeField] private Image demonImage;
    [SerializeField] private TMP_Text demonDescription;
    [SerializeField] private DemonInventoryDialog dialogContainer;
    [SerializeField] private List<PackCollection> allPossibleDialogs;


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
        demonDescription.text = chosenDemonSO.demonName;

        foreach(var pack in dialogContainer.DialogPacks.Packs){
            foreach (GameObject item in pack.DialogPairs)
            {
                item.SetActive(false);
            }
            pack.gameObject.SetActive(false);
        }
        dialogContainer.DialogPacks.Packs[0].gameObject.SetActive(true);
        dialogContainer.DialogPacks.gameObject.SetActive(false);
        dialogContainer.ResetVariables();


        dialogContainer.DialogPacks = allPossibleDialogs.Where(x => x.demon == chosenDemonSO).First();
        dialogContainer.DialogPacks.gameObject.SetActive(true);
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
    public void OnCloseDemonInventoryButtonPressed()
    {
        gameObject.SetActive(false);
    }
}