using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperInRoom : PickableItem
{
    [SerializeField] GameObject newspaper;
    [SerializeField] NewspaperSO newspaperSO;

    public override void OnClick()
    {
        OpenNewspaper();
    }

    private void OpenNewspaper()
    {
        newspaper.SetActive(true);
        newspaper.GetComponent<NewspaperManager>().OnStart(newspaperSO);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
