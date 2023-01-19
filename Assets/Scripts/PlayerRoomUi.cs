using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomUi : MonoBehaviour
{

    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject necronomiconCanvas;

    public void OnOpenMapClick()
    {
        GameController.GetInstance().SwitchWindow(cityMap, this.gameObject);
    }

    public void OnOpenInventoryButtonClicked()
    {
        GameController.GetInstance().SwitchWindow(inventoryScreen, playerRoomCanvas);
    }

    public void OnCloseInventoryButtonClicked()
    {
        GameController.GetInstance().SwitchWindow(playerRoomCanvas, inventoryScreen);
    }

    public void OnOpenNecronomiconButtonClicked()
    {
        GameController.GetInstance().SwitchWindow(necronomiconCanvas, playerRoomCanvas);
    }

    public void OnCloseNecronomiconButtonClicked()
    {
        GameController.GetInstance().SwitchWindow(playerRoomCanvas, necronomiconCanvas);
    }
}
