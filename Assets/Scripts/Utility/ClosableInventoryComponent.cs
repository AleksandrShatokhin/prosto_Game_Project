using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosableInventoryComponent : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject arrowToBack;

    private void OnEnable()
    {
        inventory.SetActive(false);

        if (arrowToBack != null)
        {
            arrowToBack.SetActive(false);
        }
    }

    private void OnDisable()
    {
        inventory.SetActive(true);

        if (arrowToBack != null)
        {
            arrowToBack.SetActive(true);
        }
    }
}
