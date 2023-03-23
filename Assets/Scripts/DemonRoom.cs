using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DemonRoom : MonoBehaviour, IStartable
{
    private GameObject playerRoom;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;
    [SerializeField] private GameObject demonRoomUi;

    private NewspaperSO newspaperSO;

    void IStartable.OnStart(DemonSO demonSO, GameObject playerRoom)
    {
        this.currentDemonSO = demonSO;
        this.playerRoom = playerRoom;

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
        GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject, true);
        GameController.GetInstance().GetComponent<CallCreator>().GenerateCall_On();
        Destroy(this.gameObject,1.1f);
    }

    public DemonSO GetCurrentDemonSO => currentDemonSO;
}
