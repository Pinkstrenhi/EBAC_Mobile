using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    [Header("Power Up")]
        public float duration;
    protected override void OnCollect()
    {
        base.OnCollect();
        PowerUpStart();
    }

    protected virtual void PowerUpStart()
    {
        Debug.Log("Power Up Start");
        Invoke(nameof(PowerUpEnd),duration);
    }
    protected virtual void PowerUpEnd()
    {
        Debug.Log("Power Up End");
        PlayerController.Instance.SetPowerUpState("");
        PlayerController.Instance.ResetPowerUpMaterial();
    }
}
