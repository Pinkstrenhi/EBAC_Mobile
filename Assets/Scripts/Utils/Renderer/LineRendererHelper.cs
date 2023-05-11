using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererHelper : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Transform> positions;

    private void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        lineRenderer.positionCount = positions.Count;
    }

    private void Update()
    {
        for (var i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i,positions[i].position);
        }
    }
}
