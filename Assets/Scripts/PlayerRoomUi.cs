using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomUi : MonoBehaviour
{
    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject necronomiconCanvas;

    public void OnCloseNecronomiconButtonClicked()
    {
        GameController.GetInstance().SwitchWindow(playerRoomCanvas, necronomiconCanvas);
    }
}
