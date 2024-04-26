using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private DraggableObject dragObject;
    [SerializeField] private UnityEvent onEnterRoom, onExitRoom;

    private void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        dragObject.CanDrag = false;
        onEnterRoom.Invoke();
      }
    }

    private void OnTriggerExit(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        dragObject.CanDrag = true;
        onExitRoom.Invoke();
      }
    }
}
