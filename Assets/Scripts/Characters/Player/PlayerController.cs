using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    public float speed = 1f;
    private Vector3 _targetPosition;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    [Header("Power Up")] 
        public bool invincible;
        public TextMeshProUGUI powerUpState;
        public Material powerUpMaterialBase;
        public Material powerUpMaterialSpeed;
        public Material powerUpMaterialInvincible;
        public Material powerUpMaterialFly;
    [Header("Lerp")] 
        public Transform target;
        public float lerpSpeed = 1f;
    [Header("Scenes")] 
        public GameObject sceneFinal;
    [Header("Tags")]
        public string tagToCheckEnemy = "Enemy";
        public string tagToCheckFinishLine = "FinishLine";

    private void Start()
    {
        _startPosition = transform.position;
        powerUpMaterialBase = gameObject.GetComponent<Renderer>().material;
        ResetSpeed();
    }
    private void Update()
    {
        if (!_canRun)
        {
            return;
        }
        _targetPosition = target.position;
        _targetPosition.y = transform.position.y;
        _targetPosition.z = transform.position.z;
        transform.Translate(transform.forward * (speed * Time.deltaTime));
        transform.position = Vector3.Lerp(transform.position,_targetPosition,lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(tagToCheckEnemy))
        {
            if (invincible)
            {
                return;
            }
            GameFinal();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagToCheckFinishLine))
        {
            if (invincible)
            {
                return;
            }
            GameFinal();
        }
    }

    private void GameFinal()
    {
        _canRun = false;
        sceneFinal.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region Power Up

        #region Visual Reference

            public void SetPowerUpState(string powerUpStateText)
            {
                powerUpState.text = powerUpStateText;
            }
            public void SetPowerUpMaterial(Material powerUpMaterialToChange)
            {
                gameObject.GetComponent<Renderer>().material = powerUpMaterialToChange;
            }
            public void ResetPowerUpMaterial()
            {
                gameObject.GetComponent<Renderer>().material = powerUpMaterialBase;
            }

        #endregion

        #region Power Up Speed

            public void PowerUpSpeed(float powerUpSpeed)
            {
                _currentSpeed = powerUpSpeed;
            }
            public void ResetSpeed()
            {
                _currentSpeed = speed;
            }

        #endregion

        #region Power Up Invincible

            public void PowerUpInvincible(bool powerUpInvincible)
            {
                invincible = powerUpInvincible;
            }

        #endregion
        
        #region Power Up Fly

            public void PowerUpFly(float amount, float duration, float animationDuration, Ease ease)
            {
                transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
                Invoke(nameof(ResetFly),duration);
            }

            public void ResetFly()
            {
                transform.DOMoveY(_startPosition.y, 0.1f);
            }

        #endregion

    #endregion
}
