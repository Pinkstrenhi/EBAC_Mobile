using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : PowerUpBase
{
    [Header("Power Up Speed")]
        public float amountToSpeed;
    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.Instance.PowerUpSpeed(amountToSpeed);
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.Instance.ResetSpeed();
    }
}
