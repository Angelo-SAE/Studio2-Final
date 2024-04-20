using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private DraggableObject dragObject;
    [SerializeField] private AudioSource roomAudio;

    private void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        dragObject.CanDrag = false;
        try
        {
          roomAudio.mute = false;
        } catch{}
      }
    }

    private void OnTriggerExit(Collider col)
    {
      if(col.gameObject.tag == "Player")
      {
        dragObject.CanDrag = true;
        try
        {
          roomAudio.mute = true;
        } catch{}
      }
    }
}
