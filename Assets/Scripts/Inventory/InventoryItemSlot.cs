using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//

public class InventoryItemSlot : MonoBehaviour, IClickable
{
    private bool isItemSelected;
    private Color defaultColor;

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

    private void Start()
    {
        isItemSelected = false;
        defaultColor = this.gameObject.GetComponent<UnityEngine.UI.Image>().color;
    }

    public void OnClick()
    {
        //if (ItemInSlot != null)
        //{
        //    ItemInSlot.OnItemRemove();
        //}

        if (ItemInSlot == null)
        {
            return;
        }

        if (isItemSelected == false)
        {
            isItemSelected = true;
            this.gameObject.GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            isItemSelected = false;
            this.gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
}