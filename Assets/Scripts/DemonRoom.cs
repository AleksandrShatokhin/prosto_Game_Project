using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DemonRoom : MonoBehaviour, IStartable
{
    private GameObject cityMap;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;
    [SerializeField] private GameObject demonRoomUi;
    [SerializeField] private Image symbol;
    [SerializeField] private Image newspaper;


    private NewspaperSO newspaperSO;
    private int puzzleNumber;

    void IStartable.OnStart(DemonSO demonSO, GameObject cityMap)
    {
        this.currentDemonSO = demonSO;
        this.cityMap = cityMap;

        CreateNewspaperInRoom();
        CreateSymbolInRoom();
        demonRoomUi.SetActive(true);
        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;

        puzzleWindow.GetComponentInChildren<IPuzzle>().OnPuzzleStart();
    }

    private void CreateNewspaperInRoom()
    {
        newspaperSO = GameController.GetInstance().GetCallCounter().GetNewspaper();

        if (newspaperSO == null)
        {
            newspaper.gameObject.SetActive(false);
        }
        else
        {
            newspaper.gameObject.SetActive(true);
        }
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
        //puzzleWindow.transform.GetChild(puzzleNumber).gameObject.SetActive(true);
        demonRoomUi.gameObject.SetActive(false);
    }

    public void ClickComeBack()
    {
        cityMap.SetActive(true);
        cityMap.GetComponent<CityMapManager>().ComebackToPlayerRoom();
        GameController.GetInstance().GetComponent<CallCreator>().GenerateCall_On();
        Destroy(this.gameObject);
    }

    public void ClickNewspaper(GameObject windowNewspaper)
    {
        windowNewspaper.SetActive(true);
        string note = newspaperSO.Text.ToString();
        windowNewspaper.GetComponent<NewspaperManager>().SetTextNewspaper(note);
    }

    public DemonSO GetCurrentDemonSO => currentDemonSO;
}
