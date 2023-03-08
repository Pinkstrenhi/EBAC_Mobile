using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
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
    }
}
