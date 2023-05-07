using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color startColor = Color.white;
    private Color _correctColor;
    private float _durationColor = 1f;
    private float _delayColor = 0.5f;
    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _correctColor = meshRenderer.materials[0].GetColor("_Color");
        ColorLerp();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ColorLerp();
        }
    }

    private void ColorLerp()
    {
        meshRenderer.materials[0].SetColor("_Color",startColor);
        meshRenderer.materials[0].DOColor(_correctColor, _durationColor).SetDelay(_delayColor);
    }
}
