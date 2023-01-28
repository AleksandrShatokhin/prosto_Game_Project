using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HouseOnCityMap : MonoBehaviour
{
    private Button buttonToNextRoom;
    private CityMap cityMap;

    private int maxTimeLiveCall;
    private int timer = 0;
    private int second = 1;

    private DemonSO demonSO;
    private int numberMessageToDemon;
    private int numberCitizenSprite;

    private void Start()
    {
        buttonToNextRoom = this.GetComponent<Button>();
        buttonToNextRoom.onClick.AddListener(ClickNextRoom);
    }

    private void ClickNextRoom()
    {
        CityMap cityMap = this.transform.GetComponentInParent<CityMap>();
        GameObject messageWindow = cityMap.GetMessageWindow();

        cityMap.IsPause_On();
        messageWindow.SetActive(true);
        messageWindow.GetComponent<MessageWindow>().OnStartMessageWindow(demonSO, numberMessageToDemon, numberCitizenSprite);
    }

    private void OnEnable()
    {
        this.maxTimeLiveCall = this.transform.GetComponentInParent<CityMap>().GetMaxTime();
        this.cityMap = this.transform.GetComponentInParent<CityMap>();
        GenerateDemon();
        StartCoroutine(Timer(maxTimeLiveCall));
    }

    private void GenerateDemon()
    {
        if (demonSO == null)
        {
            demonSO = GameController.GetInstance().GetDemonDataBase().GetDemon(0); // потенциально решить как выбирать номер демона (пока тестово номер 0)
            numberMessageToDemon = Random.Range(0, 3);
            numberCitizenSprite = 0; // потенциально сделать случайную генерацию номера
        }
    }

    private IEnumerator Timer(int maxTime)
    {
        while (true)
        {
            if (timer == maxTime)
            {
                demonSO = null;
                timer = 0;
                this.gameObject.SetActive(false);
            }

            if (!this.cityMap.IsPause())
            {
                timer += second;
            }
            
            yield return new WaitForSeconds(second);
        }
    }
}