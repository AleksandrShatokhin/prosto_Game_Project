using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_2_CheckSymbolComponent : BoxCheckerManager
{
    [SerializeField] private List<Image> buttonsOnPanel;
    [SerializeField] private List<Sprite> correctSymbols;
    [SerializeField] private List<Sprite> winSprites;
    [SerializeField] private GameObject closedPanel, openedPanel;

    [SerializeField] private int indicator;

    public void CheckSymbols()
    {
        bool isSymbolCorrect = false;
        int countCorrectSymbols = 0;

        foreach (Image buttonSprite in buttonsOnPanel)
        {
            if (buttonSprite.sprite == correctSymbols[indicator])
            {
                countCorrectSymbols += 1;
            }

            indicator += 1;
        }

        SetValueIsCorrectVariable(true);
        indicator = 0;

        isSymbolCorrect = (countCorrectSymbols == buttonsOnPanel.Count) ? true : false;

        if (isSymbolCorrect == true)
        {
            foreach (Image buttonSprite in buttonsOnPanel)
            {
                buttonSprite.sprite = winSprites[indicator];
                buttonSprite.transform.GetComponent<BoxButtonSpriteSwitcher>().ActiveButtonClick_Off();
                indicator += 1;
            }

            closedPanel.SetActive(false);
            openedPanel.SetActive(true);
            indicator = 0;

            UIAudioManager.instance.PlayChestOpenAudio(0.7f);
        }
        else
        {
            Debug.Log("Incorrect symbols");
        }
    }

    public override void StartCoroutineCheck() => StartCoroutine(StartDelayToCheckOnCorrected());
    public override void StopCoroutineCheck() => StopAllCoroutines();

    private IEnumerator StartDelayToCheckOnCorrected()
    {
        yield return new WaitForSeconds(1.0f);
        CheckSymbols();
    }
}
