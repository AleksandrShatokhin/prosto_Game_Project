using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnPanel : MonoBehaviour
{
    [SerializeField] private int valueButton;
    [SerializeField] private PickableItem item;

    public void SetItem(PickableItem item) => this.item = item;

    // Call on event click in inspector Unity
    public void ClickButton()
    {
        if (item == null)
        {
            return;
        }

        if (this.GetComponent<Image>().sprite != item.GetComponent<SpriteRenderer>().sprite)
        {
            this.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            valueButton = item.GetComponent<ButtonWithNumber>().GetValue();
        }

        GetComponentInParent<BoxManager>().CounterSumOfClick(valueButton);
    }
}
