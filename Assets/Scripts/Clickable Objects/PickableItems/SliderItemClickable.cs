using UnityEngine;

public class SliderItemClickable : PickableItem
{
    [SerializeField] private Sprite spriteToBox;
    public Sprite GetSpriteToBox() => spriteToBox;

    [SerializeField] private Sprite spriteToInventory;
    public override Sprite GetSpriteToInventory() => spriteToInventory;

    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
