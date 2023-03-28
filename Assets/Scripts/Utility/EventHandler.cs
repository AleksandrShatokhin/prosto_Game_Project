public static class EventHandler
{
    public delegate void SwitcherAction();
    public static event SwitcherAction SwitcherActionMouse;

    public static void TriggerMouseHandler() => SwitcherActionMouse?.Invoke();
}
