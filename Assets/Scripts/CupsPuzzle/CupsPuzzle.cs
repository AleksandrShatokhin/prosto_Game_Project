using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupsPuzzle : MonoBehaviour, IPuzzle
{
    [SerializeField] private GameObject demonRoom;
    [SerializeField] private Canvas cupsPuzzleMiniCanvas;
    public Cup ChosenCup { get; set; } = null;

    [Header("Если значение в чашке не имеет значения прописать Infinity")]
    [SerializeField] private List<float> correctWaterValues;
    [SerializeField] private List<Cup> cups;

    private void Start()
    {
        cupsPuzzleMiniCanvas.worldCamera = Camera.main;
    }

    public void CheckForAnswer()
    {
        for (int i = 0; i < correctWaterValues.Count; i++)
        {
            if ((correctWaterValues[i] != cups[i].waterLevel) && !float.IsInfinity(correctWaterValues[i]))
            {
                return;
            }
        }
        demonRoom.GetComponent<DemonRoom>().ClickComeBack();
    }

    public void OnPuzzleStart()
    {
    }

    public void OnPuzzleEnd()
    {
        
    }
}
