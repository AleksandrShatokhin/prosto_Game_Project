using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestController : MonoBehaviour
{
    [SerializeField] private DemonSO currentDemon;
    private PlayerInventory playerInventory;
    [SerializeField] private GameObject messageWindow;


    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
    }
    public void OnCheckItemsButtonClicked()
    {
        foreach (var item in currentDemon.neededItems)
        {
            if (!playerInventory.TakenItems.Contains(item))
            {
                EditorUtility.DisplayDialog("PopUp", "Wrong items were chosen", "Ok");
                return;
            }
        }
        EditorUtility.DisplayDialog("PopUp", "Correct items were chosen", "Ok");
        return;
    }
}
