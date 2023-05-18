using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DemonRoom : MonoBehaviour, IStartable, IFinaly
{
    private Animator anim_DemonRoom;

    private GameObject playerRoom;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;
    [SerializeField] private GameObject demonRoomUi;
    [SerializeField] private GameObject roomBlock;
    [SerializeField] private GameObject captureAnimation_GO;

    private void Start()
    {
        anim_DemonRoom = GetComponent<Animator>();
    }

    void IStartable.OnStart(DemonSO demonSO, GameObject playerRoom)
    {
        this.currentDemonSO = demonSO;
        this.playerRoom = playerRoom;

        demonRoomUi.SetActive(true);
        GameObject currentDemon = Instantiate(currentDemonSO.demonGO, currentDemonSO.demonGO.transform.position, Quaternion.identity);
        currentDemon.transform.SetParent(demonSpriteRenderer.transform);

        puzzleWindow.GetComponentInChildren<IPuzzle>().OnPuzzleStart();
    }

    public void OnStartPuzzleButtonClicked()
    {
        puzzleWindow.gameObject.SetActive(true);
        demonRoomUi.gameObject.SetActive(false);
        Destroy(demonSpriteRenderer.transform.GetChild(0).gameObject);
        roomBlock.SetActive(false);
    }

    public void ClickComeBack()
    {
        Sprite circleSprite = playerRoom.GetComponent<PlayerRoomUi>().GetPlayerRoomLoadingCircle();

        GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject, true, circleSprite);
        GameController.GetInstance().GetComponent<CallCreator>().GenerateCall_On();
        Destroy(this.gameObject, 1.1f);
    }

    public void StartAnimationDemonAppearance(GameObject box)
    {
        box.GetComponentInChildren<BoxManager>().CloseBox();
        demonRoomUi.SetActive(false);
        anim_DemonRoom.SetTrigger("isDemonAppearance");
    }

    void IFinaly.CuptureAnimationOpen()
    {
        GameController.GetInstance().AddDemonToCollection(GetCurrentDemonSO);
        puzzleWindow.SetActive(false);
        roomBlock.SetActive(true);
        captureAnimation_GO.SetActive(true);
    }

    // Вызываю на эвентах на анимации главной комнаты
    public void PlayAnimationDemonApperance() => anim_DemonRoom.enabled = true;
    public void StopAnimationDemonApperance() => anim_DemonRoom.enabled = false;

    public DemonSO GetCurrentDemonSO => currentDemonSO;

    // Временно добавляю метод, чтоб можно было в игре выйти из комнаты
    // кнопки  UI управления убрал с экрана
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ClickComeBack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnStartPuzzleButtonClicked();
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            anim_DemonRoom.SetTrigger("isDemonAppearance");
        }
    }
}


public interface IFinaly
{
    public void CuptureAnimationOpen();
}