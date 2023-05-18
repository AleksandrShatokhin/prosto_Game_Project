using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_2_CheckNumberComponent : BoxCheckerManager
{
    [SerializeField] private List<Image> buttonsOnPanel;
    [SerializeField] private List<Sprite> correctSymbols;
    [SerializeField] private List<Sprite> winSprites;

    [SerializeField] private int indicator;

    public void CheckNumbers()
    {
        bool isSymbolCorrect = false;
        int countCorrectNumbers = 0;

        foreach (Image buttonSprite in buttonsOnPanel)
        {
            if (buttonSprite.sprite == correctSymbols[indicator])
            {
                countCorrectNumbers += 1;
            }

            indicator += 1;
        }

        indicator = 0;

        isSymbolCorrect = (countCorrectNumbers == buttonsOnPanel.Count) ? true : false;

        if (isSymbolCorrect == true)
        {
            foreach (Image buttonSprite in buttonsOnPanel)
            {
                buttonSprite.sprite = winSprites[indicator];
                buttonSprite.transform.GetComponent<BoxButtonSpriteSwitcher>().ActiveButtonClick_Off();
                indicator += 1;

                UIAudioManager.instance.PlayChestOpenAudio(0.7f);
            }

            SetValueIsCorrectVariable(true);
            indicator = 0;
        }
        else
        {
            Debug.Log("Incorrect numbers");
        }
    }

    public override void StartCoroutineCheck() => StartCoroutine(StartDelayToCheckOnCorrected());
    public override void StopCoroutineCheck() => StopAllCoroutines();

    private IEnumerator StartDelayToCheckOnCorrected()
    {
        yield return new WaitForSeconds(1.0f);
        CheckNumbers();
    }
}
