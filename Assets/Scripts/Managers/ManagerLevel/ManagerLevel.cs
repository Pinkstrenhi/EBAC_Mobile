using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class ManagerLevel : MonoBehaviour
{
    public List<GameObject> levels;
    
    public Transform levelPosition;
    private GameObject _currentLevel;
    private SO_LevelPiecesBase _currentSetup;
    [SerializeField]
        private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    [SerializeField]
        private int _levelIndex;
    [Header("Pieces")] 
        public List<SO_LevelPiecesBase> soLevelPiecesBase;
        public float timeBetweenPieces = 0.3f;
    [Header("Scale")] 
        public float durationScale = 0.2f;
        public float timeToWaitScale = 0.1f;
        public Ease ease = Ease.OutBack;
        

    private void Start()
    {
        //SpawnLevel();
        CreateLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           //SpawnLevel(); 
           CreateLevelPiecesController();
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
            CleanSpawnedPieces();
            if (_currentSetup != null)
            {
                _levelIndex++;
                if (_levelIndex >= soLevelPiecesBase.Count)
                {
                    ResetLevel();
                }
            }
            _currentSetup = soLevelPiecesBase[_levelIndex];
            CreateLevelPiecesStructure(_currentSetup.levelPieceNumberStart,_currentSetup.levelPieceStart);
            CreateLevelPiecesStructure(_currentSetup.levelPieceNumber,_currentSetup.levelPiece);
            CreateLevelPiecesStructure(_currentSetup.levelPieceNumberEnd,_currentSetup.levelPieceEnd);
            ManagerColor.Instance.ChangeColorByType(_currentSetup.artType);
            StartCoroutine(nameof(ScalePieces));
        }
        private void CleanSpawnedPieces()
        {
            for (var i = (_spawnedPieces.Count - 1); i >= 0; i--)
            {
                Destroy(_spawnedPieces[i].gameObject);
            }
            _spawnedPieces.Clear();
        }
        private void CreateLevelPiecesStructure(int numberPiecesSpawn, List<LevelPieceBase> levelPieceBases)
        {
            for (int i = 0; i < numberPiecesSpawn; i++)
            {
                CreateLevelPieces(levelPieceBases);
            }
        }
        private void CreateLevelPieces(List<LevelPieceBase> levelPieceBases)
        {
            var piece = levelPieceBases[Random.Range(0, levelPieceBases.Count)];
            var spawnedPiece = Instantiate(piece, levelPosition);
            if (_spawnedPieces.Count > 0)
            {
                var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
                spawnedPiece.transform.position = lastPiece.endPiece.position;
            }

            foreach (var pieceArt in spawnedPiece.GetComponentsInChildren<PieceArt>())
            {
                pieceArt.ChangePieceArt(ManagerArt.Instance.GetSetupByArtType(_currentSetup.artType).gameObject);
            }
            _spawnedPieces.Add(spawnedPiece);
        }

    #endregion

    #region Scale

    private IEnumerator ScalePieces()
    {
        foreach (var piece in _spawnedPieces)
        {
            piece.transform.localScale = Vector3.zero;
        }
        yield return null;
        for (var i = 0; i < _spawnedPieces.Count; i++)
        {
            _spawnedPieces[i].transform.DOScale(1, durationScale).SetEase(ease);
            yield return new WaitForSeconds(timeToWaitScale);
        }
    }

    #endregion
}
