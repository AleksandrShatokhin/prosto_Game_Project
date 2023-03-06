using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour, IClickable
{
    [SerializeField] private Image itemIcon;
    private PickableItem itemInSlot = null;
    public PickableItem ItemInSlot
    {
        get
        {
            return itemInSlot;
        }
        set
        {
            itemInSlot = value;
            if (value == null)
            {
                itemIcon.sprite = null;
                itemIcon.color = new Color(1, 1, 1, 0);
            }
            else
            {
                itemIcon.sprite = value.GetComponent<SpriteRenderer>().sprite;
                itemIcon.color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void OnClick()
    {
        if (ItemInSlot != null)
            ItemInSlot.OnItemRemove();
    }


}
