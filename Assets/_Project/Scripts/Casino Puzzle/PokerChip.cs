using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerChip : Interactable
{
    [SerializeField] private int section, chip;
    [SerializeField] private PokerChipSet currentChipSet;
    [SerializeField] private SetupChipSets chipSpawner;
    [SerializeField] private BoolObject isSwapping;

    public override void Interact()
    {
      if(!isSwapping.value)
      {
        AddSelectedChip();
      }
    }

    private void AddSelectedChip()
    {
      if(CheckIfCurrentSectionIsMax(currentChipSet.chipSet[section][chip]))
      {
        switch(chip)
        {
          case(0):
          currentChipSet.sectionValues[section] += 1;
          break;
          case(1):
          currentChipSet.sectionValues[section] += 5;
          break;
          case(2):
          currentChipSet.sectionValues[section] += 25;
          break;
        }
        chipSpawner.SpawnChip(section, chip, currentChipSet.chipSet[section][chip]);
        currentChipSet.chipSet[section][chip]++;
      }
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
