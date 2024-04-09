using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : Interactable
{
    public override void Interact()
    {
      gameObject.SetActive(false);
    }
}
