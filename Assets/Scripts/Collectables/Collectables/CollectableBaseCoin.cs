using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBaseCoin : CollectableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp;
    public float minDistance;

    private void Start()
    {
        ManagerAnimatorCoins.Instance.RegisterCoin(this);
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        collider.enabled = false;
        collect = true;
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        if (!collect)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, 
                PlayerController.Instance.transform.position, lerp * Time.deltaTime);
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
        {
            HideItems();
            Destroy(gameObject);
        }
    }
}
