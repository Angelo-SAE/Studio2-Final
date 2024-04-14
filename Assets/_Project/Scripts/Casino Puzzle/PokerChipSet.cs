using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PokerChipSet", menuName = "GeneralScriptableObjects/PokerChipSet", order = 100)]
public class PokerChipSet : ScriptableObject
{
    private int size = 3, maxValue = 5;
    public int[] sectionOne = new int[3];
    public int[] sectionTwo = new int[3];
    public int[] sectionThree = new int[3];
    public int[] sectionFour = new int[3];
    public int[] sectionFive = new int[3];
    public int[] sectionSix = new int[3];

    private void OnValidate()
    {
      sectionOne = CheckForCorrectValues(sectionOne);
      sectionTwo = CheckForCorrectValues(sectionTwo);
      sectionThree = CheckForCorrectValues(sectionThree);
      sectionFour = CheckForCorrectValues(sectionFour);
      sectionFive = CheckForCorrectValues(sectionFive);
      sectionSix = CheckForCorrectValues(sectionSix);
    }

    private int[] CheckForCorrectValues(int[] section)
    {
      if(section.Length != size)
      {
        Debug.LogWarning("Don't Change Array Size");
        Array.Resize(ref section, size);
      }

      for(int a = 0; a < size; a++)
      {
        if(section[a] > maxValue)
        {
          section[a] = maxValue;
        } else if(section[a] < 0)
        {
          section[a] = 0;
        }
      }
      return section;
    }
}
