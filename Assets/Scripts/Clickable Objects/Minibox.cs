using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minibox : MonoBehaviour, IClickable
{
    [SerializeField] private Sprite spriteOpenMinibox;
    [SerializeField] private GameObject lockPanel;

    public void OnClick()
    {
        lockPanel.SetActive(true);
    }

    public void ClosePanel() => GameController.GetInstance().ClosePanel(lockPanel);

    public void SwitchSpriteMinibox() => this.GetComponent<SpriteRenderer>().sprite = spriteOpenMinibox;
}
