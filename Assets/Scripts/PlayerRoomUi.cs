using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomUi : MonoBehaviour
{
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject playerRoomCanvas;
    [SerializeField] private GameObject necronomiconCanvas;
    [SerializeField] private GameObject phone;

    public void OnCloseNecronomiconButtonClicked()
    {
        GameController.GetInstance().SwitchWindow(playerRoomCanvas, necronomiconCanvas);
    }

    public PhoneInPlayerRoom GetPhoneController() => phone.GetComponent<PhoneInPlayerRoom>();
}
