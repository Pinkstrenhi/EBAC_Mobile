using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ManagerLevel : MonoBehaviour
{
    public List<GameObject> levels;
    
    public Transform levelPosition;
    private GameObject _currentLevel;
    [SerializeField]private int _levelIndex;
    [Header("Pieces")]
        public List<LevelPieceBase> levelPiecesStart;
        public List<LevelPieceBase> levelPieces;
        public List<LevelPieceBase> levelPiecesEnd;
        private List<LevelPieceBase> _spawnedPieces;
        public int numberPiecesStart = 3;
        public int numberPieces = 5;
        public int numberPiecesEnd = 1;
        public float timeBetweenPieces = 0.3f;

    private void Awake()
    {
        //SpawnLevel();
        CreateLevel();
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

    #region Level Pieces

        private void CreateLevel()
        {
            CreateLevelPiecesController();
        }

        private void CreateLevelPiecesController()
        {
            _spawnedPieces = new List<LevelPieceBase>();
            CreateLevelPiecesStructure(numberPiecesStart,levelPiecesStart);
            CreateLevelPiecesStructure(numberPieces,levelPieces);
            CreateLevelPiecesStructure(numberPiecesEnd,levelPiecesEnd);
        }

        private void CreateLevelPiecesStructure(int numberPiecesSpawn, List<LevelPieceBase> levelPieceBases)
        {
            for (int i = 0; i < numberPiecesSpawn; i++)
            {
                CreateLevelPieces(levelPieceBases);
            }
        }

        /*private IEnumerator CreateLevelPiecesCoroutine()
        {
            for (int i = 0; i < numberPieces; i++)
            {
                CreateLevelPieces(levelPieces);
                yield return new WaitForSeconds(timeBetweenPieces);
            }
        }*/

        private void CreateLevelPieces(List<LevelPieceBase> levelPieceBases)
        {
            var piece = levelPieceBases[Random.Range(0, levelPieceBases.Count)];
            var spawnedPiece = Instantiate(piece, levelPosition);
            if (_spawnedPieces.Count > 0)
            {
                var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
                spawnedPiece.transform.position = lastPiece.endPiece.position;
            }
            _spawnedPieces.Add(spawnedPiece);
        }

    #endregion
}
