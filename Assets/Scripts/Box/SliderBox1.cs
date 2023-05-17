using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBox1 : MonoBehaviour
{
    [SerializeField] private Box_1 box_1;
    [SerializeField] private Slider slider;
    [SerializeField] private SliderItemClickable sliderItemClicable;

    private void Start()
    {
        slider.interactable = false;
    }

    public void ClickOnSliderHandler(Image image)
    {
        PlayerInventory inventory = box_1.GetPlayerInventory();

        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == sliderItemClicable)
                {
                    image.enabled = true;
                    image.sprite = slot.ItemInSlot.GetComponent<SliderItemClickable>().GetSpriteToBox();
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    slider.interactable = true;
                    return;
                }
            }
        }

        if (image.enabled == false)
        {
            GameController.GetInstance().DisplayMessageOnScreen("Нужно найти переключатель!");
        }
    }

    public void OnValueChangedSlider() // calling in the slider component
    {
        if (slider.value == 2)
        {
            slider.interactable = false;
            StartCoroutine(RotatBox());
        }
    }

    private IEnumerator RotatBox()
    {
        yield return new WaitForSeconds(0.5f);
        box_1.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        box_1.ButtonOnPanelApperance();
    }
}
