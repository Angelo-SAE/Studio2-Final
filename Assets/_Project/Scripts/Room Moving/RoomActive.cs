using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActive : MonoBehaviour
{
    [SerializeField] private int expansionActivateNumber;
    [SerializeField] private Current2D expansionNumber;
    [SerializeField] private GameObject spriteHolder;
    private int currentExpansion;
    private bool active;

    private void Start()
    {
      currentExpansion = expansionNumber.cameraNumber;
      CheckToActivate();
    }

    private void Update()
    {
      if(currentExpansion != expansionNumber.cameraNumber && !active)
      {
        currentExpansion = expansionNumber.cameraNumber;
        CheckToActivate();
      }
    }

    private void CheckToActivate()
    {
      if(expansionActivateNumber == currentExpansion)
      {
        active = true;
        spriteHolder.SetActive(true);
      } else {
        spriteHolder.SetActive(false);
      }
    }
}
