using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DemonRoom : MonoBehaviour, IStartable
{
    private Animator anim_DemonRoom;

    private GameObject playerRoom;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;
    [SerializeField] private GameObject demonRoomUi;

    private NewspaperSO newspaperSO;

    private void Start()
    {
        anim_DemonRoom = GetComponent<Animator>();
    }

    void IStartable.OnStart(DemonSO demonSO, GameObject playerRoom)
    {
        this.currentDemonSO = demonSO;
        this.playerRoom = playerRoom;

        demonRoomUi.SetActive(true);
        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;
        demonSpriteRenderer.gameObject.SetActive(false);

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

    public void StartAnimationDemonAppearance(GameObject box)
    {
        box.GetComponentInChildren<BoxManager>().CloseBox();
        demonRoomUi.SetActive(false);
        anim_DemonRoom.SetTrigger("isDemonAppearance");
    }

    public DemonSO GetCurrentDemonSO => currentDemonSO;
}
