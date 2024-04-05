using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private Publisher publisher;
    [SerializeField] private Mode mode;
    private bool isActive;

    private void Start()
    {
      publisher.NotifySubscribers();
    }

    private void Update()
    {
      ChangeMode();
    }

    private void ChangeMode()
    {
      if(Input.GetButtonDown("ModeChange"))
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
