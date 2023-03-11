public static class SelectedItem
{
    private static InventoryItemSlot selectedItem = null;

    public static InventoryItemSlot GetSelectedItem() => selectedItem;
    public static void SelectItem(InventoryItemSlot item) => selectedItem = item;
    public static void DeselectItem() => selectedItem = null;
}
