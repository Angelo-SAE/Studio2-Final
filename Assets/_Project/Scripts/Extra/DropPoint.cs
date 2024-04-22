using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropPoint : Interactable
{
    [SerializeField] private GameObjectObject heldObject;
    [SerializeField] private GameObject dropLocation, holdLocation;
    [SerializeField] private bool canPickBackUp, startsWithObject;
    [SerializeField] private UnityEvent extras;
    [SerializeField] private string tagToCheck;
    [SerializeField] private GameObject currentObject;

    public GameObject CurrentObject => currentObject;

    private void Start()
    {
      if(!startsWithObject)
      {
        currentObject = null;
      }
    }

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
      } else if(heldObject.value is not null && currentObject is not null)
      {
        if(heldObject.value.tag == tagToCheck)
        {
          SwapObject();
        }
      }
    }

    private void PeformDrop()
    {
      currentObject = heldObject.value;
      heldObject.value.transform.SetParent(dropLocation.transform);
      ResetTransform(heldObject.value);
      heldObject.value = null;
      extras.Invoke();
    }

    private void PickUpObject()
    {
      heldObject.value = currentObject;
      heldObject.value.transform.SetParent(holdLocation.transform);
      ResetTransform(heldObject.value);
      currentObject = null;
      extras.Invoke();
    }

    private void SwapObject()
    {
      GameObject tempObj = heldObject.value;
      heldObject.value = currentObject;
      heldObject.value.transform.SetParent(holdLocation.transform);
      ResetTransform(heldObject.value);
      currentObject = tempObj;
      currentObject.transform.SetParent(dropLocation.transform);
      ResetTransform(currentObject);
      extras.Invoke();
    }

    private void ResetTransform(GameObject resetObj)
    {
      resetObj.transform.localPosition = Vector3.zero;
      resetObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

}
