using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPots : MonoBehaviour
{
    [SerializeField] private DropPoint[] potSpots;
    [SerializeField] private GameObject[] pots;
    [SerializeField] private UnityEvent completed;

    public void OnNotify()
    {
      if(CheckForCompletion())
      {
        completed.Invoke();
      }
    }

    private bool CheckForCompletion()
    {
      for(int a = 0; a < 7; a++)
      {
        if(potSpots[a].CurrentObject != pots[a])
        {
          return false;
        }
      }
      return true;
    }
}
