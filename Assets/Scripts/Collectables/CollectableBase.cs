using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    [Header("Sounds")] 
        public AudioSource audioSource;
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void HideItems()
    {
        if (graphicItem != null)
        {
            graphicItem.SetActive(false);
        }
        Invoke(nameof(HideObject),timeToHide); 
    }
    protected virtual void Collect()
    {
        HideItems();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
