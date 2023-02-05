using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HouseOnCityMap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private Button buttonToNextRoom;
    private CityMap cityMap;

    private int maxTimeLiveCall;
    private int timer;
    private int second = 1;

    private DemonSO demonSO;
    private int numberMessageToDemon;
    private int numberCitizenSprite;

    private void Start()
    {
        buttonToNextRoom = this.GetComponent<Button>();
        buttonToNextRoom.onClick.AddListener(OpenMessageWindow);
    }

    private void OpenMessageWindow()
    {
        CityMap cityMap = this.transform.GetComponentInParent<CityMap>();
        GameObject messageWindow = cityMap.GetMessageWindow();

        cityMap.IsPause_On();
        messageWindow.SetActive(true);
        messageWindow.GetComponent<MessageWindow>().OnStartMessageWindow(demonSO, numberMessageToDemon, numberCitizenSprite, this.gameObject);
    }

    private void OnEnable()
    {
        this.maxTimeLiveCall = this.transform.GetComponentInParent<CityMap>().GetMaxTime();
        this.cityMap = this.transform.GetComponentInParent<CityMap>();

        timer = maxTimeLiveCall;
        GenerateDemon();
        StartCoroutine(Timer(maxTimeLiveCall));
    }

    private void GenerateDemon()
    {
        if (demonSO == null)
        {
            demonSO = GameController.GetInstance().GetDemonDataBase().GetDemon(0); // потенциально решить как выбирать номер демона (пока тестово номер 0)
            numberMessageToDemon = Random.Range(0, demonSO.message.Count);
            numberCitizenSprite = Random.Range(0, demonSO.citizenSprite.Count);
        }
    }

    private IEnumerator Timer(int maxTime)
    {
        while (true)
        {
            if (timer == 0)
            {
                demonSO = null;
                timer = maxTime;
                this.gameObject.SetActive(false);
            }

            if (!this.cityMap.IsPause() && second != 0)
            {
                timerText.text = timer.ToString();
                timer -= second;
            }
            
            yield return new WaitForSeconds(second);
        }
    }

    public int GetCurrentSecond() => second;
    public void SwitchHouseTimer(int newVariable)
    {
        second = newVariable;

        if (newVariable == 0)
        {
            timerText.text = "wait";
        }
        else
        {
            timerText.text = timer.ToString();
        }
    }
}