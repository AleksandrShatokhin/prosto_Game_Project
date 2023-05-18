using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_2_CheckSliderManager : BoxCheckerManager
{
    [SerializeField] private List<Slider> sliders;
    [SerializeField] private List<int> correctNumbers;
    [SerializeField] private Sprite winSprite;

    [SerializeField] private int indicator;

    private void CheckNumbers()
    {
        bool isSymbolCorrect = false;
        int countCorrectNumbers = 0;

        foreach (Slider slider in sliders)
        {
            if (slider.value == correctNumbers[indicator])
            {
                countCorrectNumbers += 1;
                indicator += 1;
            }
        }

        indicator = 0;

        isSymbolCorrect = (countCorrectNumbers == sliders.Count) ? true : false;

        if (isSymbolCorrect == true)
        {
            foreach (Slider slider in sliders)
            {
                slider.gameObject.GetComponent<SliderBox2>().SetWinSpriteToHandler(winSprite);
                slider.interactable = false;

                UIAudioManager.instance.PlayChestOpenAudio(0.7f);
            }

            SetValueIsCorrectVariable(true);
        }
        else
        {
            Debug.Log("Incorrect Slider Numbers");
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
