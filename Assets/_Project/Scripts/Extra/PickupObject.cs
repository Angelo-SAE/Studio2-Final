using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : Interactable
{
    [SerializeField] private GameObjectObject heldObject;
    [SerializeField] private GameObject holdLocation;

    public override void Interact()
    {
      Debug.Log(heldObject.value);
      if(heldObject.value is null)
      {
        PickUpCurrentObject();
      }
      Debug.Log(heldObject.value);
    }

    private void PickUpCurrentObject()
    {
      heldObject.value = this.gameObject;
      gameObject.transform.SetParent(holdLocation.transform);
      transform.localPosition = Vector3.zero;
    }
}
