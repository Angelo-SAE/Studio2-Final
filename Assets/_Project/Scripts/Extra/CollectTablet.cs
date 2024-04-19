using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectTablet : Interactable
{
    [SerializeField] private BoolObject hasTablet;
    [SerializeField] private UnityEvent collectTablet;

    public override void Interact()
    {
      hasTablet.value = true;
      collectTablet.Invoke();
      gameObject.SetActive(false);
    }
}
