using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTablet : Interactable
{
    [SerializeField] private BoolObject hasTablet;

    public override void Interact()
    {
      hasTablet.value = true;
      gameObject.SetActive(false);
    }
}
