using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class MouseHandler : MonoBehaviour
{
    private StateMouseHandler stateMouseHandler;

    private void Start()
    {
        stateMouseHandler = StateMouseHandler.Allowed;

        EventHandler.SwitcherActionMouse += SwitchActionMouseHandler;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (stateMouseHandler == StateMouseHandler.Forbidden)
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

    private void SwitchActionMouseHandler()
    {
        if (stateMouseHandler == StateMouseHandler.Allowed)
        {
            stateMouseHandler = StateMouseHandler.Forbidden;
        }
        else
        {
            stateMouseHandler = StateMouseHandler.Allowed;
        }
    }


    private void OnDisable()
    {
        EventHandler.SwitcherActionMouse -= SwitchActionMouseHandler;
    }
}