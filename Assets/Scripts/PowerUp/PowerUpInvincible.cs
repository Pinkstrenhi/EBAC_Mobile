using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : PowerUpBase
{
    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.Instance.SetPowerUpState("Invincible");
        PlayerController.Instance.SetPowerUpMaterialInvincible();
        PlayerController.Instance.SetInvincible(true);
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.Instance.SetPowerUpState("");
        PlayerController.Instance.ResetPowerUpMaterial();
        PlayerController.Instance.SetInvincible(false);
    }
}
