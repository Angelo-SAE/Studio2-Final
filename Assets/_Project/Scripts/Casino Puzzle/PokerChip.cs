using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerChip : Interactable
{
    [SerializeField] private int section, chip;
    [SerializeField] private PokerChipSet currentChipSet;
    [SerializeField] private SetupChipSets chipSpawner;

    public override void Interact()
    {
      int currentChips = GetCurrentSectionFromNumber(section, chip);
      chipSpawner.SpawnChip(section, chip, currentChips);
    }

    private int GetCurrentSectionFromNumber(int a, int b)
    {
      switch(a)
      {
        case(0):
        if(CheckIfCurrentSectionIsMax(currentChipSet.sectionOne[b]))
        {
          currentChipSet.sectionOne[b]++;
          return currentChipSet.sectionOne[b];
        }
        break;
        case(1):
        if(CheckIfCurrentSectionIsMax(currentChipSet.sectionTwo[b]))
        {
          currentChipSet.sectionTwo[b]++;
          return currentChipSet.sectionTwo[b];
        }
        break;
        case(2):
        if(CheckIfCurrentSectionIsMax(currentChipSet.sectionThree[b]))
        {
          currentChipSet.sectionThree[b]++;
          return currentChipSet.sectionThree[b];
        }
        break;
        case(3):
        if(CheckIfCurrentSectionIsMax(currentChipSet.sectionFour[b]))
        {
          currentChipSet.sectionFour[b]++;
          return currentChipSet.sectionFour[b];
        }
        break;
        case(4):
        if(CheckIfCurrentSectionIsMax(currentChipSet.sectionFive[b]))
        {
          currentChipSet.sectionFive[b]++;
          return currentChipSet.sectionFive[b];
        }
        break;
        case(5):
        if(CheckIfCurrentSectionIsMax(currentChipSet.sectionSix[b]))
        {
          currentChipSet.sectionSix[b]++;
          return currentChipSet.sectionSix[b];
        }
        break;
      }
      return 1000000;
    }

    private bool CheckIfCurrentSectionIsMax(int currentChips)
    {
      if(currentChips < 5)
      {
        return true;
      }
      return false;
    }
}
