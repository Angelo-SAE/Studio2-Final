using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Publisher publisher;
    [SerializeField] private Mode mode;
    private bool isActive;

    private void Update()
    {
      Pause();
    }

    private void Pause()
    {
      if(Input.GetButtonDown("Pause"))
      {
        if(mode.mode3D)
        {
          isActive = true;
          mode.mode3D = false;
          publisher.NotifySubscribers();
        } else if(!mode.mode3D && isActive)
        {
          isActive = false;
          mode.mode3D = true;
          publisher.NotifySubscribers();
        }
      }
    }
}
