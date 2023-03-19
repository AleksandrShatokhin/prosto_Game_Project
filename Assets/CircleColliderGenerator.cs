using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class CircleColliderGenerator : MonoBehaviour
{

    private TrailRenderer trailRenderer;
    private EdgeCollider2D edgeCollider2D;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();

        GameObject edgeCollider = new GameObject("TrailCollider", typeof(EdgeCollider2D));
        edgeCollider2D = edgeCollider.GetComponent<EdgeCollider2D>();
    }
    private void Update()
    {
        UpdateColliderPoints();
    }

    private void UpdateColliderPoints()
    {
        List<Vector2> points = new List<Vector2>();

        for (var i = 0; i < trailRenderer.positionCount; i++)
        {
            points.Add(trailRenderer.GetPosition(i));
        }
        edgeCollider2D.SetPoints(points);
    }
}
