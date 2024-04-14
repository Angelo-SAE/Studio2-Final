using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupChipSets : MonoBehaviour
{
    [SerializeField] private int currentSet;
    [SerializeField] private GameObject[] pokerChips;
    [SerializeField] private PokerChipSet currentChipSet;
    [SerializeField] private PokerChipSet[] sets;
    [SerializeField] private GameObject[] redChipSpawn, blueChipSpawn, greenChipSpawn;
    private GameObject chipsHolder;
    private bool previousSet;

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.J))
      {
        OnNotify();
      }
    }

    public void OnNotify()
    {
      if(previousSet)
      {
        DeletePreviousSet();
      } else {
        previousSet = true;
        CreateNewSet();
      }
    }

    private void DeletePreviousSet()
    {
      Destroy(chipsHolder);
      CreateNewSet();
    }

    private void CreateNewSet()
    {
      chipsHolder = new GameObject("Chips Holder");
      chipsHolder.transform.position = gameObject.transform.position;
      FlushCurrentChipSet();
      SetBaseChips();
    }

    private void SetBaseChips()
    {
      for(int a = 0; a < 3; a++)
      {
        for(int b = 0; b < 3; b++)
        {
          SpawnChips(a, b, GetSectionFromNumber(a), GetColorSetFromNumber(b));
        }
      }
    }

    private GameObject[] GetColorSetFromNumber(int a)
    {
      switch(a)
      {
        case(0):
        return redChipSpawn;
        break;
        case(1):
        return blueChipSpawn;
        break;
        case(2):
        return greenChipSpawn;
        break;
      }
      return null;
    }

    private int[] GetSectionFromNumber(int a)
    {
      switch(a)
      {
        case(0):
        return sets[currentSet].sectionOne;
        break;
        case(1):
        return sets[currentSet].sectionTwo;
        break;
        case(2):
        return sets[currentSet].sectionThree;
        break;
        case(3):
        return sets[currentSet].sectionFour;
        break;
        case(4):
        return sets[currentSet].sectionFive;
        break;
        case(5):
        return sets[currentSet].sectionSix;
        break;
      }
      return null;
    }

    private void SpawnChips(int sectionNumber, int chip, int[] section, GameObject[] whatColor)
    {
      for(int a = 0; a < section[chip]; a++)
      {
        Instantiate(pokerChips[chip], new Vector3(whatColor[sectionNumber].transform.position.x, whatColor[sectionNumber].transform.position.y + (0.005f * a), whatColor[sectionNumber].transform.position.z), pokerChips[chip].transform.rotation, chipsHolder.transform);
      }
    }

    public void SpawnChip(int sectionNumber, int chip, int chipNumber)
    {
      GameObject[] whatColor = GetColorSetFromNumber(chip);
      Instantiate(pokerChips[chip], new Vector3(whatColor[sectionNumber].transform.position.x, whatColor[sectionNumber].transform.position.y + (0.005f * (chipNumber - 1)), whatColor[sectionNumber].transform.position.z), pokerChips[chip].transform.rotation, chipsHolder.transform);
    }

    private void FlushCurrentChipSet()
    {
      for(int a = 0; a < 3; a++)
      {
        currentChipSet.sectionOne[a] = 0;
        currentChipSet.sectionTwo[a] = 0;
        currentChipSet.sectionThree[a] = 0;
        currentChipSet.sectionFour[a] = 0;
        currentChipSet.sectionFive[a] = 0;
        currentChipSet.sectionSix[a] = 0;
      }
    }
}
