using UnityEngine;

public class TriggerMouseComponent : MonoBehaviour
{
    //private void OnEnable() => EventHandler.TriggerMouseHandler();
    //private void OnDisable() => EventHandler.TriggerMouseHandler();

    private void OnEnable()
    {
        Debug.Log(this.gameObject.name + "������ �������");
        EventHandler.TriggerMouseHandler();
    }

    private void OnDisable()
    {
        Debug.Log(this.gameObject.name + "������ �������");
        EventHandler.TriggerMouseHandler();
    }
}
