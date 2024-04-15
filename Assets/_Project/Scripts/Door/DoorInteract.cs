using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interactable
{
    [SerializeField] private GameObject doorLockedAudio;
    [SerializeField] private Animator animator;
    [SerializeField] private bool canOpen;
    [SerializeField] private bool needsKey;
    [SerializeField] private bool NS, EW;
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private GameObject doorKey;
    private bool open;

    public bool CanOpen
    {
      set => canOpen = value;
    }

    public override void Interact()
    {
      if(!CheckForKey() && canOpen)
      {
        CheckOpenDirection();
      }
    }

    private bool CheckForKey()
    {
      if(needsKey)
      {
        if(doorKey.activeInHierarchy == false)
        {
          needsKey = false;
          return false;
        }
      } else {
        return false;
      }
      Instantiate(doorLockedAudio, transform.position, transform.rotation, transform);
      return true;
    }

    private void CheckOpenDirection()
    {
      animator.SetBool("DoorOpenN", false);
      animator.SetBool("DoorOpenS", false);
      animator.SetBool("DoorOpenE", false);
      animator.SetBool("DoorOpenW", false);
      if(NS)
      {
        if(playerPosition.position.z < transform.position.z)
        {
          animator.SetBool("DoorOpenN", true);
          OpenCloseDoor();
        } else {
          animator.SetBool("DoorOpenS", true);
          OpenCloseDoor();
        }
      } else if(EW)
      {
        if(playerPosition.position.x < transform.position.x)
        {
          animator.SetBool("DoorOpenE", true);
          OpenCloseDoor();
        } else {
          animator.SetBool("DoorOpenW", true);
          OpenCloseDoor();
        }
      }
    }

    private void OpenCloseDoor()
    {
      if(!open)
      {
        PlayAnimation("DoorOpen", true);
      } else if(open)
      {
        PlayAnimation("DoorOpen", false);
      }
    }

    private void PlayAnimation(string animationBool, bool state)
    {
      animator.SetBool(animationBool, state);
      open = state;
    }
}
