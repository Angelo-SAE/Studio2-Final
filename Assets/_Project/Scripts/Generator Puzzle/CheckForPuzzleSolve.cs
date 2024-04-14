using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPuzzleSolve : MonoBehaviour
{
    [SerializeField] private PieceGrid grid;
    [SerializeField] private int gridX, gridY;
    [SerializeField] private Vector2Int startPosition, endPosition;
    private bool powered;
    private int lastDirection;

    public bool CheckForSolved()
    {
      Vector2Int currentPosition = startPosition;
      lastDirection = 5;
      powered = true;
      if(grid.pieceGrid[currentPosition.x, currentPosition.y].W)
      {
        while(true)
        {
          if(powered)
          {
            grid.pieceGrid[currentPosition.x, currentPosition.y].SetColorPowered();
            if(currentPosition == endPosition && grid.pieceGrid[currentPosition.x, currentPosition.y].E)
            {
              return true;
            } else {
              currentPosition = CheckAndContinuePowerDirection(currentPosition);
            }
          } else {
            break;
          }
        }
      }
      return false;
    }

    private Vector2Int CheckAndContinuePowerDirection(Vector2Int currentPosition)
    {
      try
      {
        if(grid.pieceGrid[currentPosition.x, currentPosition.y].N && currentPosition.y < gridY && lastDirection != 0)
        {
          if(grid.pieceGrid[currentPosition.x, currentPosition.y + 1].S)
          {
            lastDirection = 2;
            return new Vector2Int(currentPosition.x, currentPosition.y + 1);
          } else {
            powered = false;
          }
        }
        if(grid.pieceGrid[currentPosition.x, currentPosition.y].E && currentPosition.x < gridX && lastDirection != 1)
        {
          if(grid.pieceGrid[currentPosition.x + 1, currentPosition.y].W)
          {
            lastDirection = 3;
            return new Vector2Int(currentPosition.x + 1, currentPosition.y);
          } else {
            powered = false;
          }
        }
        if(grid.pieceGrid[currentPosition.x, currentPosition.y].S && currentPosition.y > 0 && lastDirection != 2)
        {
          if(grid.pieceGrid[currentPosition.x, currentPosition.y - 1].N)
          {
            lastDirection = 0;
            return new Vector2Int(currentPosition.x, currentPosition.y - 1);
          } else {
            powered = false;
          }
        }
        if(grid.pieceGrid[currentPosition.x, currentPosition.y].W && currentPosition.x > 0 && lastDirection != 3)
        {
          if(grid.pieceGrid[currentPosition.x - 1, currentPosition.y].E)
          {
            lastDirection = 1;
            return new Vector2Int(currentPosition.x - 1, currentPosition.y);
          } else {
            powered = false;
          }
        }
      }
      catch{}
      powered = false;
      return currentPosition;
    }
}
