public class SliderItemClickable : PickableItem
{
    public override void OnClick()
    {
        base.OnClick();
        this.gameObject.SetActive(false);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
