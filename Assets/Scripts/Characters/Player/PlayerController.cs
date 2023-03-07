using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")] 
        public Transform target;
        public float lerpSpeed = 1f;
    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    private Vector3 _targetPosition;
    private bool _canRun;

    private void Start()
    {
        _canRun = true;
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
            _canRun = false;
        }
    }
}
