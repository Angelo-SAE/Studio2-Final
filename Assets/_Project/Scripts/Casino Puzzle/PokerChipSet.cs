using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PokerChipSet", menuName = "GeneralScriptableObjects/PokerChipSet", order = 100)]
public class PokerChipSet : ScriptableObject
{
    private int sectionSize = 3, maxValue = 5, valueSize = 6, maxTotal = 155;
    public int[][] chipSet = new int[6][];
    public int[] sectionValues = new int[6];
    public int[] sectionOne = new int[3];
    public int[] sectionTwo = new int[3];
    public int[] sectionThree = new int[3];
    public int[] sectionFour = new int[3];
    public int[] sectionFive = new int[3];
    public int[] sectionSix = new int[3];

    private void Awake()
    {
      OnValidate();
    }

    private void OnValidate()
    {
      sectionOne = CheckForCorrectValues(0, sectionOne);
      sectionTwo = CheckForCorrectValues(1, sectionTwo);
      sectionThree = CheckForCorrectValues(2, sectionThree);
      sectionFour = CheckForCorrectValues(3, sectionFour);
      sectionFive = CheckForCorrectValues(4, sectionFive);
      sectionSix = CheckForCorrectValues(5, sectionSix);
      sectionValues = CheckSectionValues(sectionValues);
    }

    private int[] CheckForCorrectValues(int setNumber, int[] section)
    {
      if(section.Length != sectionSize)
      {
        Debug.LogWarning("Don't Change Array Size");
        Array.Resize(ref section, sectionSize);
      }

      for(int a = 0; a < sectionSize; a++)
      {
        if(section[a] > maxValue)
        {
          section[a] = maxValue;
        } else if(section[a] < 0)
        {
          section[a] = 0;
        }
      }

      chipSet[setNumber] = section;
      return section;
    }

    private int[] CheckSectionValues(int[] section)
    {
      if(section.Length != valueSize)
      {
        Debug.LogWarning("Don't Change Array Size");
        Array.Resize(ref section, valueSize);
      }

      for(int a = 0; a < valueSize; a++)
      {
        if(section[a] > maxTotal)
        {
          section[a] = maxTotal;
        } else if(section[a] < 0)
        {
          section[a] = 0;
        }
      }

      return section;
    }
}
