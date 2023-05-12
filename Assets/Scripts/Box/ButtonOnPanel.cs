using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnPanel : MonoBehaviour
{
    [SerializeField] private ButtonColor valueButtonColor;
    [SerializeField] private PickableItem item;
    [SerializeField] private Color colorToMarker;
    [SerializeField] private Sprite markerSprite;
    [SerializeField] private StateButton currentStateButton;
    public StateButton GetStateButton() => currentStateButton;

    public void SetItem(PickableItem item) => this.item = item;

    // Call on event click in inspector Unity
    public void ClickButton()
    {
        if (item == null)
        {
            return;
        }

        currentStateButton = StateButton.Yes;

        if (this.GetComponent<Image>().sprite != item.GetComponent<ButtonWithNumber>().GetSpriteToBox())
        {
            this.GetComponent<Image>().sprite = item.GetComponent<ButtonWithNumber>().GetSpriteToBox();
            valueButtonColor = item.GetComponent<ButtonWithNumber>().GetButtonColor();
        }

        GetComponentInParent<BoxManager>().SetClickOnButton(valueButtonColor);
        GetComponentInParent<Box1ColorMarkers>().SetNewColorToMarker(markerSprite);
    }

    public void StartOpanButton() => StartCoroutine(OpanableButton());

    private IEnumerator OpanableButton(float delay = 0.05f)
    {
        Color buttonColor = this.GetComponent<Image>().color;

        while (buttonColor.a < 255)
        {
            yield return new WaitForSeconds(delay);

            buttonColor = new Color(1, 1, 1, buttonColor.a + delay);

            this.GetComponent<Image>().color = buttonColor;
            this.GetComponent<Button>().interactable = true;
        }
    }
}

public enum StateButton
{
    Yes,
    No
}