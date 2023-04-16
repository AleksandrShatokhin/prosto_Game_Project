using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    private StateMouseHandler stateMouseHandler;

    [SerializeField] Sprite defaltCursor;
    [SerializeField] Sprite cursorBook, cursorEye, cursorHand;

    private void Start()
    {
        EventHandler.SwitcherActionMouse += SwitchActionMouseHandler;
        SetCursorSprite(defaltCursor);
        StartCoroutine(CursorHandlerRuntime());
    }

    IEnumerator CursorHandlerRuntime(float delay = 0.1f)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && stateMouseHandler == StateMouseHandler.Allowed)
            {
                if (hit.collider.gameObject.layer == (int)Layers.Readable || hit.collider.gameObject.layer == (int)Layers.Viewable || hit.collider.gameObject.layer == (int)Layers.Pickable)
                {
                    SetCursorSprite(hit.collider.gameObject.layer);
                }
                else
                {
                    SetCursorSprite(defaltCursor);
                }
            }
            else
            {
                SetCursorSprite(defaltCursor);
            }
        }
    }

    private void SetCursorSprite(int leyers)
    {
        switch (leyers)
        {
            case (int)Layers.Readable:
                SetCursorSprite(cursorBook);
                break;
            case (int)Layers.Viewable:
                SetCursorSprite(cursorEye);
                break;
            case (int)Layers.Pickable:
                SetCursorSprite(cursorHand);
                break;
        }
    }

    private void SetCursorSprite(Sprite sprite)
    {
        Cursor.SetCursor(sprite.texture, Vector2.zero, CursorMode.Auto);
    }

    private void SwitchActionMouseHandler() => stateMouseHandler = (stateMouseHandler == StateMouseHandler.Allowed) ? StateMouseHandler.Forbidden : StateMouseHandler.Allowed;

    private void OnDisable()
    {
        EventHandler.SwitcherActionMouse -= SwitchActionMouseHandler;
    }
}

public enum Layers
{
    Readable = 7,
    Viewable = 8,
    Pickable = 9
}