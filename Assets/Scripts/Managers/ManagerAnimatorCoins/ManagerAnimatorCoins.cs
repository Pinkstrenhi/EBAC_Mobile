using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;


public class ManagerAnimatorCoins : Core.Singleton.Singleton<ManagerAnimatorCoins>
{
    public List<CollectableBaseCoin> coins;
    [Header("Scale")]
        public float durationScale = 0.2f;
        public float timeToWaitScale = 0.1f;
        public Ease ease = Ease.OutBack;

    private void Start()
    {
        coins = new List<CollectableBaseCoin>();
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartScale();    
        }
    }*/

    public void RegisterCoin(CollectableBaseCoin collectableBaseCoin)
    {
        if (!coins.Contains(collectableBaseCoin))
        {
            coins.Add(collectableBaseCoin);
            collectableBaseCoin.transform.localScale = Vector3.zero;
        }
    }

    #region Scale
        private IEnumerator ScaleCoins()
        {
            foreach (var coin in coins)
            {
                coin.transform.localScale = Vector3.zero;
            }
            Sort();
            yield return null;
            for (var i = 0; i < coins.Count; i++)
            {
                coins[i].transform.DOScale(1, durationScale).SetEase(ease);
                yield return new WaitForSeconds(timeToWaitScale);
            }
        }

        public void StartScale()
        {
            StartCoroutine(nameof(ScaleCoins));
        }

        public void Sort()
        {
            coins = coins.OrderBy(x => Vector3.Distance(this.transform.position,
                x.transform.position)).ToList();
        }
    #endregion
}
