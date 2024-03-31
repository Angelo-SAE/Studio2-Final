using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PieceGrid", menuName = "GeneralScriptableObjects/PieceGrid", order = 100)]
public class PieceGrid : ScriptableObject
{
    public GeneratorPiece[,] pieceGrid = new GeneratorPiece[30,30];
}
