using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperInRoom : PickableItem
{
    [SerializeField] GameObject newspaper;

    public override void OnClick()
    {
        OpenNewspaper();
    }

    private void OpenNewspaper()
    {
        newspaper.SetActive(true);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
