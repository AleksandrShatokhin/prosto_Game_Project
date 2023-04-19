using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//

public class InventoryItemSlot : MonoBehaviour, IClickable
{
    public bool IsItemSelected { get; private set; }
    private Sprite defaultSprite;

    private Sprite itemSprite = null;
    public void SetItemSprite(Sprite sprite) => itemSprite = sprite;

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
                if (itemSprite == null)
                {
                    itemIcon.sprite = value.GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    itemIcon.sprite = value.GetComponent<PickableItem>().GetSpriteToInventory();
                }

                itemIcon.color = new Color(1, 1, 1, 1);
            }
        }
    }

    private void Start()
    {
        IsItemSelected = false;
        defaultSprite = this.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        if (ItemInSlot == null)
        {
            return;
        }

        if (IsItemSelected == false)
        {
            SelectItem();
        }
        else
        {
            DeselectItem();
        }
    }

    private void SelectItem()
    {
        this.GetComponentInParent<PlayerInventory>().CheckIsSelectedItemInInventory();
        IsItemSelected = true;
        this.gameObject.GetComponent<Image>().sprite = GetComponentInParent<PlayerInventory>().GetCircleSprite();
    }

    public void DeselectItem()
    {
        IsItemSelected = false;
        this.gameObject.GetComponent<Image>().sprite = defaultSprite;
        itemSprite = null;
    }
}