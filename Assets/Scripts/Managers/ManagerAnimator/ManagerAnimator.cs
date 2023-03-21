using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAnimator : MonoBehaviour
{
    public Animator animator;
    public List<SetupAnimator> setupAnimators;
    public enum AnimationType
    {
        Idle, 
        Run, 
        Dead
    }

    public void Play(AnimationType animationType,float currentSpeedFactor = 1f)
    {
        setupAnimators.ForEach(i =>
        {
            if (i.animationType == animationType)
            {
                animator.SetTrigger(i.animationTrigger);
                animator.speed = i.speed * currentSpeedFactor;
            } 
        });
        /*foreach (var setupAnimator in setupAnimators)
        {
            if (setupAnimator.animationType == animationType)
            {
                animator.SetTrigger(setupAnimator.animationTrigger);
                break;
            }
        }*/
    }

    private void Update()
    {
        PlayAnimation(KeyCode.Alpha1,AnimationType.Run);
        PlayAnimation(KeyCode.Alpha2,AnimationType.Dead);
        PlayAnimation(KeyCode.Alpha3,AnimationType.Idle);
    }

    private void PlayAnimation(KeyCode keycode, AnimationType animationType)
    {
        if (Input.GetKeyDown(keycode))
        {
            Play(animationType);
        } 
    }
}
[System.Serializable]
public class SetupAnimator
{
    public ManagerAnimator.AnimationType animationType;
    public string animationTrigger;
    public float speed = 1f;
}
