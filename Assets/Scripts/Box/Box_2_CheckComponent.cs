using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_2_CheckComponent : MonoBehaviour
{
    [SerializeField] private List<Image> buttonsOnPanel;
    [SerializeField] private List<Sprite> correctSymbols;
    [SerializeField] private List<Sprite> winSprites;

    [SerializeField] private int indicator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckSymbols();
        }
    }

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

        indicator = 0;

        isSymbolCorrect = (countCorrectSymbols == 4) ? true : false;

        if (isSymbolCorrect == true)
        {
            foreach (Image buttonSprite in buttonsOnPanel)
            {
                buttonSprite.sprite = winSprites[indicator];
                indicator += 1;
            }

            indicator = 0;
        }
        else
        {
            Debug.Log("Incorrect symbols");
        }
    }

    public void StartCoroutineCheck() => StartCoroutine(StartDelayToCheckOnCorrected());
    public void StopCoroutineCheck() => StopCoroutine(StartDelayToCheckOnCorrected());

    private IEnumerator StartDelayToCheckOnCorrected()
    {
        yield return new WaitForSeconds(1.0f);
        CheckSymbols();
    }
}
