using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_LevelPiecesBase : ScriptableObject
{
    public ManagerArt.ArtType artType;
    [Header("Pieces")] 
        public List<LevelPieceBase> levelPieceStart;
        public List<LevelPieceBase> levelPiece;
        public List<LevelPieceBase> levelPieceEnd;

        public int levelPieceNumberStart = 3;
        public int levelPieceNumber = 5;
        public int levelPieceNumberEnd = 1;
}
