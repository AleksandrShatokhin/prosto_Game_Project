public static class EventHandler
{
    public delegate void SwitcherAction();
    public static event SwitcherAction SwitcherActionMouse_On;
    public static event SwitcherAction SwitcherActionMouse_Off;

    public static void TriggerMouseHandler(bool valueComand)
    {
        if (valueComand == true)
        {
            SwitcherActionMouse_On?.Invoke();
        }
        else
        {
            SwitcherActionMouse_Off?.Invoke();
        }
    }
}
