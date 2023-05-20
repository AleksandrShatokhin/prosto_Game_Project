using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHandler : MonoBehaviour
{
    private StateMouseHandler stateMouseHandler;
    private bool isCircumventBanRaycast;

    private void Start()
    {
        isCircumventBanRaycast = false;
        stateMouseHandler = StateMouseHandler.Allowed;

        EventHandler.SwitcherActionMouse_On += SwitchActionMouseHandler_On;
        EventHandler.SwitcherActionMouse_Off += SwitchActionMouseHandler_Off;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (stateMouseHandler == StateMouseHandler.Forbidden)
            {
                return;
            }

            if (isCircumventBanRaycast == false && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                hit.collider.gameObject?.GetComponent<IClickable>()?.OnClick();
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }

    private void SwitchActionMouseHandler_On() => stateMouseHandler = StateMouseHandler.Forbidden;
    private void SwitchActionMouseHandler_Off() => stateMouseHandler = StateMouseHandler.Allowed;

    public void IsCircumventBanRaycast_Off() => isCircumventBanRaycast = false;
    public void IsCircumventBanRaycast_On() => isCircumventBanRaycast = true;


    private void OnDisable()
    {
        EventHandler.SwitcherActionMouse_On -= SwitchActionMouseHandler_On;
        EventHandler.SwitcherActionMouse_Off -= SwitchActionMouseHandler_Off;
    }
}