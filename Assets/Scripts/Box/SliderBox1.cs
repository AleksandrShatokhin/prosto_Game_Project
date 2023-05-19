using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBox1 : MonoBehaviour
{
    [SerializeField] private Box_1 box_1;
    [SerializeField] private Slider slider;
    [SerializeField] private Image handleSlider;
    [SerializeField] private SliderItemClickable sliderItemClicable;

    private void Start()
    {
        slider.interactable = false;
    }

    public void ClickOnSliderHandler(GameObject button)
    {
        PlayerInventory inventory = box_1.GetPlayerInventory();

        foreach (InventoryItemSlot slot in inventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == sliderItemClicable)
                {
                    handleSlider.enabled = true;
                    handleSlider.sprite = slot.ItemInSlot.GetComponent<SliderItemClickable>().GetSpriteToBox();
                    inventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    slider.interactable = true;
                    button.SetActive(false);
                    UIAudioManager.instance.PlaySliderClickAudio(0.6f);
                    return;
                }
            }
        }

        if (handleSlider.enabled == false)
        {
            GameController.GetInstance().DisplayMessageOnScreen("Нужно найти переключатель!");
        }
    }

    public void OnValueChangedSlider() // calling in the slider component
    {
        if (slider.value == 2)
        {
            slider.interactable = false;
            UIAudioManager.instance.PlaySliderUnlockedAudio(0.8f);
            StartCoroutine(RotatBox());
        }
        else
        {
            UIAudioManager.instance.PlaySliderClickAudio(0.5f);
        }
    }

    private IEnumerator RotatBox()
    {
        yield return new WaitForSeconds(0.5f);
        box_1.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        box_1.ButtonOnPanelApperance();
    }
}
