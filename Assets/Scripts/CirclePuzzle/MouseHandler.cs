using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHandler : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private int numberOfLinePositions = 0;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                ConnectNewLetter(hit);
                hit.collider.gameObject?.GetComponent<IClickable>().OnClick();
            }
        }
    }

    private void ConnectNewLetter(RaycastHit2D hit)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(numberOfLinePositions, hit.collider.transform.position);
        numberOfLinePositions++;
    }

    public void ResetLine()
    {
        lineRenderer.positionCount = 0;
        numberOfLinePositions = 0;
    }
}