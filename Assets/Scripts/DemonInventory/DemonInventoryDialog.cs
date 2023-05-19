using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DemonInventoryDialog : MonoBehaviour
{
    [SerializeField] public PackCollection DialogPacks;

    private int _currentDialogPair = 0;
    private int _currentDialogPack = 0;
    public void OnAskDemonButtonClicked()
    {
        try
        {
            if (_currentDialogPair < DialogPacks.Packs[_currentDialogPack].DialogPairs.Count)
            {
                GameObject textPairToActivate = DialogPacks.Packs[_currentDialogPack].DialogPairs[_currentDialogPair];
                textPairToActivate.SetActive(true);
                IEnumerator textFadeCoroutine = FadeIn(textPairToActivate);
                StartCoroutine(textFadeCoroutine);

                _currentDialogPair++;
            }
            else
            {
                DialogPacks.Packs[_currentDialogPack].gameObject.SetActive(false);
                _currentDialogPack++;
                if (_currentDialogPack < DialogPacks.Packs.Count)
                {
                    _currentDialogPair = 0;
                    DialogPacks.Packs[_currentDialogPack].gameObject.SetActive(true);
                    
                    GameObject textPairToActivate = DialogPacks.Packs[_currentDialogPack].DialogPairs[_currentDialogPair];
                    textPairToActivate.SetActive(true);
                    IEnumerator textFadeCoroutine = FadeIn(textPairToActivate);
                    StartCoroutine(textFadeCoroutine);

                    _currentDialogPair++;
                }
                else
                {
                    Debug.Log("Reached last message");
                    _currentDialogPair--;
                }
            }
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Debug.Log("Reached last message");
            _currentDialogPair--;
        }
    }

    private IEnumerator FadeIn(GameObject pair)
    {
        float duration = 1f;
        float startTime = Time.time;
        TMP_Text[] texts = pair.GetComponentsInChildren<TMP_Text>();
        while (Time.time < startTime + duration)
        {
            foreach (TMP_Text text in texts)
            {
                Color clr = text.color;
                Color newColor = new Color(clr.r, clr.g, clr.b, clr.a + (Time.deltaTime / duration));
                text.color = newColor;
            }
            yield return null;
        }
    }

    public void ResetVariables()
    {
        _currentDialogPack = 0;
        _currentDialogPair = 0;
    }
}
