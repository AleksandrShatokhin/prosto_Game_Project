using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWindow : MonoBehaviour
{
    [SerializeField] private DemonRoom demonRoom;
    [SerializeField] private GameObject demonRoomUI;
    
    private void OnEnable()
    {
        Instantiate(demonRoom.GetCurrentDemonSO.puzzlePrefab, transform.position, Quaternion.identity, this.transform);
    }


    public void OnBackButtonPressed()
    {
        this.gameObject.SetActive(false);
        demonRoomUI.SetActive(true);
    }
}
