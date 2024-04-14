using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractDetection : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private GameObject rayPosition;
    [SerializeField] private float rayLength;
    [SerializeField] private InteractableObject interactableObject;


    void Update()
    {
      CheckForInteractableAndSet();
    }

    private void CheckForInteractableAndSet()
    {
      RaycastHit hit;
      if(Physics.Raycast(rayPosition.transform.position, rayPosition.transform.forward, out hit, rayLength))
      {
        if(hit.transform is not null && hit.transform.gameObject.layer == Mathf.Log(interactLayer, 2))
        {
          interactableObject.interactableObject = hit.transform.gameObject.GetComponent<Interactable>();
        } else {
          interactableObject.interactableObject = null;
        }
      } else {
        interactableObject.interactableObject = null;
      }
    }
}
