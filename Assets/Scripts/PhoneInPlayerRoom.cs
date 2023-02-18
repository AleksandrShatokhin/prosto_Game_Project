using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInPlayerRoom : MonoBehaviour
{
    [SerializeField] GameObject playerRoom, cityMap, houses;

    private int numberHouse;

    public void CallCame(int numberHouse)
    {
        this.numberHouse = numberHouse;

        this.gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;
    }

    public void OpenMessageWimdow()
    {
        if (GameController.GetInstance().GetComponent<CallCreator>().IsCallCreated())
        {
            return;
        }

        GameController.GetInstance().SwitchWindow(cityMap, playerRoom);
        GameObject house = houses.transform.GetChild(numberHouse).gameObject;
        house.SetActive(true);
        house.GetComponent<CallOnMap>().OpenMessageWindow();
    }
}