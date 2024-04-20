using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SetupChipSets : MonoBehaviour
{
    [SerializeField] private int currentSet;
    [SerializeField] private AudioSource setupSound, placeChipSound;
    [SerializeField] private GameObject[] pokerChips;
    [SerializeField] private PokerChipSet currentChipSet;
    [SerializeField] private PokerChipSet[] sets;
    [SerializeField] private GameObjectss[] chips;
    [SerializeField] private BoolObject isSwapping;
    [SerializeField] private UnityEvent updateScoreBoard, disableScoreBoard, enableScoreBoard, disableTextBoard, enableTextBoard, disableStartButton, enableDataShard;
    [SerializeField] private Animator swapperAnimation;
    [SerializeField] private TMP_Text displayText;
    private bool started;
    private GameObject chipsHolder;
    private bool previousSet;

    public void OnNotify()
    {
      StartCoroutine(SpawnNextSet());
    }

    private void SpawnSet()
    {
      setupSound.Play();
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
          SpawnChips(a, b);
        }
      }
      updateScoreBoard.Invoke();
    }

    private void SpawnChips(int sectionNumber, int chip)
    {
      for(int a = 0; a < sets[currentSet].chipSet[sectionNumber][chip]; a++)
      {
        switch(chip)
        {
          case(0):
          currentChipSet.sectionValues[sectionNumber] += 1;
          break;
          case(1):
          currentChipSet.sectionValues[sectionNumber] += 5;
          break;
          case(2):
          currentChipSet.sectionValues[sectionNumber] += 25;
          break;
        }
        chips[sectionNumber].objectss[chip].objects[a].SetActive(true);
      }
    }

    public void SpawnChip(int sectionNumber, int chip, int chipNumber)
    {
      placeChipSound.Play();
      chips[sectionNumber].objectss[chip].objects[chipNumber].SetActive(true);
      updateScoreBoard.Invoke();
      if(CheckForSolved())
      {
        StartCoroutine(SpawnNextSet());
      }
    }

    private bool CheckForSolved()
    {
      for(int a = 3; a < 6; a++)
      {
        if(currentChipSet.sectionValues[a] != sets[currentSet].sectionValues[a])
        {
          return false;
        }
      }
      return true;
    }

    private void FlushCurrentChipSet()
    {
      for(int a = 0; a < 6; a++)
      {
        for(int b = 0; b < 3; b++)
        {
          for(int c = 0; c < 5; c++)
          {
            if(chips[a].objectss[b].objects[c].activeSelf)
            {
              chips[a].objectss[b].objects[c].SetActive(false);
            }
          }
          currentChipSet.chipSet[a][b] = 0;
        }
        currentChipSet.sectionValues[a] = 0;
      }
      updateScoreBoard.Invoke();
    }

    public void FlushCurrentChipSetSection(int section)
    {
      for(int a = 0; a < 3; a++)
      {
        for(int b = 0; b < 5; b++)
        {
          if(chips[section].objectss[a].objects[b].activeSelf)
          {
            chips[section].objectss[a].objects[b].SetActive(false);
          }
        }
        currentChipSet.sectionValues[section] = 0;
        currentChipSet.chipSet[section][a] = 0;
      }
      updateScoreBoard.Invoke();
    }

    private IEnumerator SpawnNextSet()
    {
      isSwapping.value = true;
      if(started)
      {
        currentSet++;
        if(currentSet < sets.Length)
        {
          swapperAnimation.SetTrigger("Swap");
          displayText.text = "Loading Next Set";
          disableScoreBoard.Invoke();
          enableTextBoard.Invoke();
          yield return new WaitForSeconds(2f);
          SpawnSet();
          yield return new WaitForSeconds(2f);
          disableTextBoard.Invoke();
          enableScoreBoard.Invoke();
          isSwapping.value = false;
        } else {
          swapperAnimation.SetTrigger("Swap");
          displayText.text = "!!!You Won!!!";
          disableScoreBoard.Invoke();
          enableTextBoard.Invoke();
          yield return new WaitForSeconds(2f);
          FlushCurrentChipSet();
          enableDataShard.Invoke();
          yield return new WaitForSeconds(2f);
          displayText.text = "Take It";
        }
      } else {
        swapperAnimation.SetTrigger("Swap");
        displayText.text = "Loading First Set";
        disableScoreBoard.Invoke();
        enableTextBoard.Invoke();
        yield return new WaitForSeconds(2f);
        disableStartButton.Invoke();
        SpawnSet();
        yield return new WaitForSeconds(2f);
        disableTextBoard.Invoke();
        enableScoreBoard.Invoke();
        started = true;
        isSwapping.value = false;
      }
    }
}

[System.Serializable]
public struct GameObjects
{
  public GameObject[] objects;
}

[System.Serializable]
public struct GameObjectss
{
  public GameObjects[] objectss;
}
