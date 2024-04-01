using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool canOpen;
    private bool open;

    public bool CanOpen
    {
      set => canOpen = value;
    }

    public override void Interact()
    {
      if(canOpen && !open)
      {
        animator.SetBool("DoorOpen", true);
        open = true;
      } else if(canOpen && open)
      {
        animator.SetBool("DoorOpen", false);
        open = false;
      }
    }
}
