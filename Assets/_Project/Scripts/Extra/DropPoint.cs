using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropPoint : Interactable
{
    [SerializeField] private GameObjectObject heldObject;
    [SerializeField] private GameObject dropLocation, holdLocation;
    [SerializeField] private bool canPickBackUp;
    [SerializeField] private UnityEvent extras;
    [SerializeField] private string tagToCheck;
    private GameObject currentObject;

    public override void Interact()
    {
      if(heldObject.value is not null && currentObject is null)
      {
        if(heldObject.value.tag == tagToCheck)
        {
          PeformDrop();
        }
      } else if(heldObject.value is null && currentObject is not null)
      {
        PickUpObject();
      }
    }

    private void PeformDrop()
    {
      currentObject = heldObject.value;
      heldObject.value.transform.SetParent(dropLocation.transform);
      heldObject.value.transform.localPosition = Vector3.zero;
      heldObject.value.transform.localRotation = Quaternion.Euler(Vector3.zero);
      heldObject.value = null;
      extras.Invoke();
    }

    private void PickUpObject()
    {
      heldObject.value = currentObject;
      heldObject.value.transform.SetParent(holdLocation.transform);
      heldObject.value.transform.localPosition = Vector3.zero;
      heldObject.value.transform.localRotation = Quaternion.Euler(Vector3.zero);
      currentObject = null;
    }

}
