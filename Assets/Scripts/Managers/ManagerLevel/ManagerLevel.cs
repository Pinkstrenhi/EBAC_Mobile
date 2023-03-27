using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    public List<GameObject> levels;
    public Transform levelPosition;
    private GameObject _currentLevel;
    [SerializeField]private int _levelIndex;

    private void Awake()
    {
        SpawnLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           SpawnLevel(); 
        }
    }

    private void SpawnLevel()
    {
        if (_currentLevel != null)
        {
           Destroy(_currentLevel);
           _levelIndex++;
           if (_levelIndex >= levels.Count)
           {
               ResetLevel();
           }
        }
        _currentLevel = Instantiate(levels[_levelIndex],levelPosition);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevel()
    {
        _levelIndex = 0;
    }
}
