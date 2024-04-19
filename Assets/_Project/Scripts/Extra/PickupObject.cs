using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : Interactable
{
    [SerializeField] private GameObjectObject heldObject;
    [SerializeField] private GameObject holdLocation;

    public override void Interact()
    {
      if(heldObject.value is null)
      {
        PickUpCurrentObject();
      }
    }

    private void PickUpCurrentObject()
    {
      heldObject.value = this.gameObject;
      gameObject.transform.SetParent(holdLocation.transform);
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
