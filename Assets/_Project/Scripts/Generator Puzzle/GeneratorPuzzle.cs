using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPuzzle : MonoBehaviour
{
    [SerializeField] private int gridX, gridY;
    [SerializeField] private PieceGrid grid;
    [SerializeField] private CheckForPuzzleSolve check;
    [SerializeField] private Renderer endRenderer;
    [SerializeField] private Material solvedMaterial, unSolvedMaterial;
    private bool solved;

    public void MoveUp(int xPos)
    {
      GeneratorPiece tempLast = grid.pieceGrid[xPos, gridY - 1];
      for(int a = gridY - 1; a > 0; a--)
      {
        grid.pieceGrid[xPos, a] = grid.pieceGrid[xPos, a - 1];
      }
      grid.pieceGrid[xPos, 0] = tempLast;
      SetSquarePositionsInColumn(xPos);
    }

    public void MoveDown(int xPos)
    {
      GeneratorPiece tempFirst = grid.pieceGrid[xPos, 0];
      for(int a = 0; a < gridY - 1; a++)
      {
        grid.pieceGrid[xPos, a] = grid.pieceGrid[xPos, a + 1];
      }
      grid.pieceGrid[xPos, gridY - 1] = tempFirst;
      SetSquarePositionsInColumn(xPos);
    }

    private void SetSquarePositionsInColumn(int xPos)
    {
      for(int b = 0; b < gridY; b++)
      {
        grid.pieceGrid[xPos,b].RTransform.anchoredPosition = new Vector2(0.1f + (0.15f * (xPos + 1)), 0.1f + (0.15f * (b + 1)));
      }
      for(int a = 0; a < gridX; a++)
      {
        for(int b = 0; b < gridY; b++)
        {
          grid.pieceGrid[a,b].SetColorBack();
        }
      }
      solved = check.CheckForSolved();
      DisplaySolved();
    }

    private void DisplaySolved()
    {
      if(solved)
      {
        endRenderer.material = solvedMaterial;
      } else {
        endRenderer.material = unSolvedMaterial;
      }
    }

    //private void SetSquarePositions()
    //{
    //  for(int a = 0; a < gridX; a++)
    //  {
    //    for(int b = 0; b < gridY; b++)
    //    {
    //      grid.pieceGrid[a,b].anchoredPosition = new Vector2(0.1f + (0.15f * (a + 1)), 0.1f + (0.15f * (b + 1)));
    //    }
    //  }
    //}



}
