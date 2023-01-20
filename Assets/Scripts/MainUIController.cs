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

    private void Start()
    {
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
}
