using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRoom : MonoBehaviour
{
    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;

    public void OnStartDemonRoom(DemonSO demonSO)
    {
        this.currentDemonSO = demonSO;

        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;
    }

    public void OnStartPuzzleButtonClicked()
    {
        puzzleWindow.gameObject.SetActive(true);
    }

    public void ClickComeBack()
    {
        GameController.GetInstance().SwitchWindow(cityMap, this.gameObject);
    }
}
