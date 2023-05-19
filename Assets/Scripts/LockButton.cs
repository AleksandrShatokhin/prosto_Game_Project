using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockButton : MonoBehaviour
{
    [SerializeField] private LockChest lockChest;
    private Button button;
    private TextMeshProUGUI textButton;

    private void Start()
    {
        textButton = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        button = this.GetComponent<Button>();
        button.onClick.AddListener(SwitchNumber);
    }

    private void SwitchNumber()
    {
        UIAudioManager.instance.PlayClickAudio();
        int value = int.Parse(textButton.text);

        value += 1;

        if (value > 9)
        {
            value = 0;
            textButton.text = value.ToString();
        }
        else
        {
            textButton.text = value.ToString();
        }

        lockChest.CheckPassword();
    }
}
