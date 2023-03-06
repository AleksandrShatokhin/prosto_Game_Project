using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWindow : MonoBehaviour
{
    [SerializeField] private DemonRoom demonRoom;
    [SerializeField] private GameObject demonRoomUI;


    private GameObject currentPuzzle;

    private void OnEnable()
    {
        //currentPuzzle = Instantiate(demonRoom.GetCurrentDemonSO.puzzlePrefab, transform.position, Quaternion.identity, this.transform);
        currentPuzzle.GetComponent<CirclePuzzle>().demonRoom = this.demonRoom;
        currentPuzzle.GetComponent<CirclePuzzle>().puzzleWindow = this.gameObject;
    }

    private void OnDisable()
    {
        Destroy(currentPuzzle);
    }

    public void OnBackButtonPressed()
    {
        this.gameObject.SetActive(false);
        demonRoomUI.SetActive(true);
    }
}
