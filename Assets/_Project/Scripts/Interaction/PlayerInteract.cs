using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InteractableObject interactableObject;

    void Update()
    {
      CheckForInteract();
    }

    private void CheckForInteract()
    {
      if(Input.GetButtonDown("Interact") && interactableObject.interactableObject is not null)
      {
        Interact();
      }
    }

    private void Interact()
    {
      interactableObject.interactableObject.Interact();
    }
}
