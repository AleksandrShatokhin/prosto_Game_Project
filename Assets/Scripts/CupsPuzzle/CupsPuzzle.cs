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
        OnPuzzleEnd();
    }

    public void OnPuzzleStart()
    {
    }

    public void OnPuzzleEnd()
    {
        //demonRoom.GetComponent<DemonRoom>().ClickComeBack();
        //GameController.GetInstance().AddDemonToCollection(demonRoom.GetComponent<DemonRoom>().GetCurrentDemonSO);
        StartCoroutine(DelayToEnd());
    }

    private IEnumerator DelayToEnd(float delay = 1.0f)
    {
        this.GetComponent<TriggerMouseComponent>().enabled = true;
        yield return new WaitForSeconds(delay);
        this.GetComponent<TriggerMouseComponent>().enabled = false;
        //demonRoom.GetComponent<DemonRoom>().ClickComeBack();
        demonRoom.GetComponent<IFinaly>().CuptureAnimationOpen();
    }
}
