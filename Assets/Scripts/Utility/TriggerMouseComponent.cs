using UnityEngine;

public class TriggerMouseComponent : MonoBehaviour
{
    private void OnEnable() => EventHandler.TriggerMouseHandler(true);
    private void OnDisable() => EventHandler.TriggerMouseHandler(false);
}
