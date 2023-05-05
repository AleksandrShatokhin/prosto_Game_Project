using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInDemonRoom : MonoBehaviour, IClickable
{
    [SerializeField] private Sprite spriteNEW;
    [SerializeField] private GameObject boxWindow;

    void IClickable.OnClick()
    {
        boxWindow.SetActive(true);
    }

    public void ChangeSprite() => this.GetComponent<SpriteRenderer>().sprite = spriteNEW;
}
