using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Power Up Coins")] 
        public float amountToCoins;
    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.Instance.SetPowerUpState("Coins");
        PlayerController.Instance.SetPowerUpMaterial(PlayerController.Instance.powerUpMaterialCoins);
        PlayerController.Instance.PowerUpCoins(amountToCoins);
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.Instance.PowerUpCoins(1);
    }
}
