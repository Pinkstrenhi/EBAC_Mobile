using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    [Header("Power Up Fly")] 
        public float amountToFly;
        public float animationDuration = 0.1f;
        public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;
    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.Instance.SetPowerUpState("Fly");
        PlayerController.Instance.SetPowerUpMaterial(PlayerController.Instance.powerUpMaterialFly);
        PlayerController.Instance.PowerUpFly(amountToFly,duration,animationDuration,ease);
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
    }
}
