using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fireplace : Interactable
{
    [SerializeField] private GameObjectObject heldObject;
    [SerializeField] private GameObject candleDropLocation;
    [SerializeField] private UnityEvent activateFires;

    public override void Interact()
    {
      if(heldObject.value is not null)
      {
        if(heldObject.value.tag == "Candle")
        {
          LightFire();
        }
      }
    }

    private void LightFire()
    {
      heldObject.value.transform.SetParent(candleDropLocation.transform);
      heldObject.value.transform.localPosition = Vector3.zero;
      heldObject.value.transform.localRotation = Quaternion.Euler(Vector3.zero);
      heldObject.value = null;
      activateFires.Invoke();
    }

}
