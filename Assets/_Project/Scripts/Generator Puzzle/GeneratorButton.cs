using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorButton : Interactable
{
    [SerializeField] private BoolObject isSolved;
    [SerializeField] private GeneratorPuzzle puzzleScript;
    [SerializeField] private bool up, down;
    [SerializeField] private int columnNumber;

    public override void Interact()
    {
      if(!isSolved.value)
      {
        if(up)
        {
          puzzleScript.MoveUp(columnNumber);
        }
        if(down)
        {
          puzzleScript.MoveDown(columnNumber);
        }
      }  
    }
}
