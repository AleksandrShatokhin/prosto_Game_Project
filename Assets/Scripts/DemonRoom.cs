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

    void IStartable.OnStart(DemonSO demonSO, GameObject cityMap)
    {
        this.currentDemonSO = demonSO;
        this.cityMap = cityMap;

        demonRoomUi.SetActive(true);
        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;

        puzzleWindow.GetComponentInChildren<IPuzzle>().OnPuzzleStart();
    }

    public void OnStartPuzzleButtonClicked()
    {
        puzzleWindow.gameObject.SetActive(true);
        demonRoomUi.gameObject.SetActive(false);
    }

    public void ClickComeBack()
    {

        //cityMap.SetActive(true);
        cityMap.GetComponent<CityMapManager>().ComebackToPlayerRoom();
        GameController.GetInstance().GetComponent<CallCreator>().GenerateCall_On();
        Destroy(this.gameObject,1f);
    }

    public DemonSO GetCurrentDemonSO => currentDemonSO;
}
