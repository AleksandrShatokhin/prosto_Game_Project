using UnityEngine;

public class TriggerMouseComponent : MonoBehaviour
{
    //private void OnEnable() => EventHandler.TriggerMouseHandler();
    //private void OnDisable() => EventHandler.TriggerMouseHandler();

    private void OnEnable()
    {
        Debug.Log(this.gameObject.name + "Первый контакт");
        EventHandler.TriggerMouseHandler();
    }

    private void OnDisable()
    {
        Debug.Log(this.gameObject.name + "Второй контакт");
        EventHandler.TriggerMouseHandler();
    }
}
