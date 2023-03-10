using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class PlayerController : Singleton<PlayerController>
{
    public float speed = 1f;
    private Vector3 _targetPosition;
    private bool _canRun;
    private float _currentSpeed;
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
            GameFinal();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagToCheckFinishLine))
        {
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

        public void PowerUpSpeed(float powerUpSpeed)
        {
            _currentSpeed = powerUpSpeed;
        }

        public void ResetSpeed()
        {
            _currentSpeed = speed;
        }

    #endregion
}
