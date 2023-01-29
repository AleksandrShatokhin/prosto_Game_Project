using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestController : MonoBehaviour
{
    [SerializeField] private DemonSO currentDemon;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private GameObject informationWindowPrefab;

    public void OnCheckItemsButtonClicked()
    {
        foreach (var item in currentDemon.neededItems)
        {
            if (!playerInventory.TakenItems.Contains(item))
            {
                GameObject wrongWindow = Instantiate(informationWindowPrefab, transform.position, Quaternion.identity);
                wrongWindow.GetComponent<InformationWindow>().SetWindowText("Вы выбрали неправильные предметы");
                return;
            }
        }

        GameObject correctWindow = Instantiate(informationWindowPrefab, transform.position, Quaternion.identity);
        correctWindow.GetComponent<InformationWindow>().SetWindowText("Вы выбрали правильные предметы");
    }
}
