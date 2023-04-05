using UnityEngine;

public class TriggerMouseComponent : MonoBehaviour
{
    private void OnEnable() => EventHandler.TriggerMouseHandler();
    private void OnDisable() => EventHandler.TriggerMouseHandler();
}
