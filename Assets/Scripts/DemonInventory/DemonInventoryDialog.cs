using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                DialogPacks.Packs[_currentDialogPack].DialogPairs[_currentDialogPair].SetActive(true);
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
                    DialogPacks.Packs[_currentDialogPack].DialogPairs[_currentDialogPair].SetActive(true);
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

    public void ResetVariables()
    {
        _currentDialogPack = 0;
        _currentDialogPair = 0;
    }
}
