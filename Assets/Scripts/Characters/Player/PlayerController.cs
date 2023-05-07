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
    private float _baseSpeedToAnimation = 5f;
    [Header("Power Up")] 
        public bool invincible;
        public TextMeshProUGUI powerUpState;
        public GameObject collectorCoin;
        public Material powerUpMaterialBase;
        public Material powerUpMaterialSpeed;
        public Material powerUpMaterialInvincible;
        public Material powerUpMaterialFly;
        public Material powerUpMaterialCoins;
    [Header("Lerp")] 
        public Transform target;
        public float lerpSpeed = 1f;
    [Header("Scenes")] 
        public GameObject sceneFinal;
    [Header("Tags")]
        public string tagToCheckEnemy = "Enemy";
        public string tagToCheckFinishLine = "FinishLine";
    [Header("Animation")] 
        public ManagerAnimator managerAnimator;
        [SerializeField] private BounceHelper _bounceHelper;
    /*private void Awake()
    {
        if (managerAnimator == null)
        {
            managerAnimator = GetComponentInChildren<ManagerAnimator>();
        }
    }*/
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
        transform.position = Vector3.Lerp(transform.position, _targetPosition, lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(tagToCheckEnemy))
        {
            if (invincible)
            {
                return;
            }
            MoveBackDead(other.transform);
            GameFinal(ManagerAnimator.AnimationType.Dead);
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
            GameFinal(ManagerAnimator.AnimationType.Idle);
        }
    }

    private void MoveBackDead(Transform moveTransform)
    {
        moveTransform.DOMoveZ(1f,0.3f).SetRelative();
    }

    private void GameFinal(ManagerAnimator.AnimationType animationType)
    {
        _canRun = false;
        sceneFinal.SetActive(true);
        managerAnimator.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun = true;
        managerAnimator.Play(ManagerAnimator.AnimationType.Run,
            _currentSpeed / _baseSpeedToAnimation);
    }

    #region Power Up

        #region Visual Reference

            public void SetPowerUpState(string text)
            {
                powerUpState.text = text;
            }
            public void SetPowerUpMaterial(Material material)
            {
                gameObject.GetComponent<Renderer>().material = material;
            }
            public void ResetPowerUpMaterial()
            {
                gameObject.GetComponent<Renderer>().material = powerUpMaterialBase;
            }

        #endregion

        #region Power Up Speed

            public void PowerUpSpeed(float amount)
            {
                _currentSpeed = amount;
            }
            public void ResetSpeed()
            {
                _currentSpeed = speed;
            }

        #endregion

        #region Power Up Invincible

            public void PowerUpInvincible(bool condition)
            {
                invincible = condition;
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

        #region Power Up Coins

            public void PowerUpCoins(float amount)
            {
                collectorCoin.transform.localScale = Vector3.one * amount;
            }

        #endregion

    #endregion

    #region Bounce

        public void Bounce()
        {
            if (_bounceHelper != null)
            {
                _bounceHelper.Bounce();
            }
        }

    #endregion
}
