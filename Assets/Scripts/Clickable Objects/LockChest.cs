using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockChest : MonoBehaviour, IClickable
{
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private List<int> correctPassword;
    private int indicatorPassword = 0;

    [SerializeField] private GameObject openableChest;

    private GameObject lockPanel;

    private void Start()
    {
        lockPanel = this.transform.GetChild(0).gameObject;
    }

    public void OnClick()
    {
        lockPanel.SetActive(true);
    }

    public void CheckPassword()
    {
        if (CheckLockCode() == true)
        {
            SwitchActiveObject();
            GameController.GetInstance().DisplayMessageOnScreen("Верный пароль");
        }
    }

    private bool CheckLockCode()
    {
        bool isPasswordCorrect = false;
        int currentSum = 0;

        foreach (GameObject button in buttons)
        {
            if (int.Parse(button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) == correctPassword[indicatorPassword])
            {
                currentSum += 1;
            }

            indicatorPassword += 1;
        }

        indicatorPassword = 0;

        return isPasswordCorrect = (currentSum == correctPassword.Count) ? true : false;
    }

    private void SwitchActiveObject()
    {
        openableChest.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ClosePanel() => GameController.GetInstance().ClosePanel(lockPanel);
}
