using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomUi : MonoBehaviour
{

    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject playerRoomCanvas;

    public void OnOpenMapClick()
    {
        Instantiate(cityMap, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void OnOpenInventoryButtonClicked()
    {
        inventoryScreen.SetActive(true);
        playerRoomCanvas.SetActive(false);
    }

    public void OnCloseInventoryButtonClicked()
    {
        playerRoomCanvas.SetActive(true);
        inventoryScreen.SetActive(false);
    }
}
