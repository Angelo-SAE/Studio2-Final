using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private DraggableObject dragObject;
    [SerializeField] private UnityEvent onEnterRoom, onExitRoom;
    private Vector3 playerPositionInRoom;

    public Vector3 PlayerPositionInRoom => playerPositionInRoom;

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

    private void OnTriggerStay(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        playerPositionInRoom = ((col.transform.position - transform.position)/15f);
      }
    }
}
