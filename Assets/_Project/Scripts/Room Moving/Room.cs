using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private DraggableObject dragObject;

    private void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        dragObject.CanDrag = false;
      }
    }

    private void OnTriggerExit(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        dragObject.CanDrag = true;
      }
    }
}
