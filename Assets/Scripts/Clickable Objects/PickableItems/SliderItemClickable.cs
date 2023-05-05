using UnityEngine;

public class SliderItemClickable : PickableItem
{
    [SerializeField] private Sprite spriteToBox;
    public Sprite GetSpriteToBox() => spriteToBox;

    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
