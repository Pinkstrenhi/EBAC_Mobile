using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAnimator : MonoBehaviour
{
    public Animation animation;
    public AnimationClip animationClip_Idle;
    public AnimationClip animationClip_Run;

    private void Update()
    {
        AnimationPlay(KeyCode.A,animationClip_Run);
        AnimationPlay(KeyCode.S,animationClip_Idle);
    }

    private void AnimationPlay(KeyCode keycode, AnimationClip animationClip)
    {
        if (Input.GetKeyDown(keycode))
        {
            animation.CrossFade(animationClip.name);
        }
    }
}
