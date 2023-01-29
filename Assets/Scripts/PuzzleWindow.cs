using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWindow : MonoBehaviour
{
    [SerializeField] private DemonRoom demonRoom;
    [SerializeField] private GameObject demonRoomUI;
    [SerializeField] private PlayerInventory playerInventory;

    private GameObject currentPuzzle;

    private void OnEnable()
    {
        int numberOfHints = GetNumberOfHints();
        currentPuzzle = Instantiate(demonRoom.GetCurrentDemonSO.puzzlePrefab, transform.position, Quaternion.identity, this.transform);
        currentPuzzle.GetComponent<CirclePuzzle>().demonRoom = this.demonRoom;
        currentPuzzle.GetComponent<CirclePuzzle>().puzzleWindow = this.gameObject;
        currentPuzzle.GetComponent<CirclePuzzle>().HandleHints(numberOfHints);
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

    public int GetNumberOfHints()
    {
        int count = 0;
        foreach (var item in demonRoom.GetCurrentDemonSO.neededItems)
        {
            if (playerInventory.TakenItems.Contains(item))
            {
                count++;
            }
        }
        return count;
    }
}
