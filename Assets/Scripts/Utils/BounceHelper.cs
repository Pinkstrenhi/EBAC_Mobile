using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
        public float durationScale = 0.2f;
        public float bounceScale = 1.2f;
        public Ease ease = Ease.OutBack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }
    public void Bounce()
    {
        transform.DOScale(bounceScale,durationScale).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
