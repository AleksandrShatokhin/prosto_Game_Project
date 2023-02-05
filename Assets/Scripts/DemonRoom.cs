using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonRoom : MonoBehaviour
{
    [SerializeField] private GameObject cityMap;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;
    [SerializeField] private GameObject demonRoomUi;
    [SerializeField] private Image symbol;

    public void OnStartDemonRoom(DemonSO demonSO)
    {
        this.currentDemonSO = demonSO;
        
        CreateSymbolInRoom();
        demonRoomUi.SetActive(true);
        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;
    }

    private void CreateSymbolInRoom()
    {
        symbol.sprite = GameController.GetInstance().GetCallCounter().GetSymbolSprite();

        if (symbol.sprite == null)
        {
            symbol.gameObject.SetActive(false);
        }
        else
        {
            symbol.gameObject.SetActive(true);
        }
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
