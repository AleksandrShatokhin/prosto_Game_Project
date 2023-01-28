using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRoom : MonoBehaviour
{
    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;
    [SerializeField] private GameObject demonRoomUi;

    public void OnStartDemonRoom(DemonSO demonSO)
    {
        this.currentDemonSO = demonSO;

        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;
    }

    public void OnStartPuzzleButtonClicked()
    {
        puzzleWindow.gameObject.SetActive(true);
        demonRoomUi.gameObject.SetActive(false);
    }

    public void ClickComeBack()
    {
        GameController.GetInstance().SwitchWindow(cityMap, this.gameObject);
    }

    public DemonSO GetCurrentDemonSO => currentDemonSO;
}
