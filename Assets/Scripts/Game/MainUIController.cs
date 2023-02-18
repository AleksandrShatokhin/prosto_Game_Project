using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI timerText, moneyCountText;

    [SerializeField] private int hours, minutes;
    [SerializeField] private int countMoney;

    private bool isPauseMode;
    [SerializeField] GameObject pauseWindow;

    private void Start()
    {
        isPauseMode = false;
        moneyCountText.text = countMoney.ToString();

        StartCoroutine(Timer());
    }

    private IEnumerator Timer(float trySecond = 1.0f)
    {
        while (true)
        {
            if (minutes == 59)
            {
                hours += 1;
                minutes = -1;
            }

            if (hours == 24)
            {
                hours = 0;
            }

            minutes += 1;

            timerText.text = string.Format("{0:00}:{1:00}", hours, minutes);

            yield return new WaitForSeconds(trySecond);
        }
    }

    public void PauseMode()
    {
        if (isPauseMode)
        {
            isPauseMode = false;
            pauseWindow.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            isPauseMode = true;
            pauseWindow.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
