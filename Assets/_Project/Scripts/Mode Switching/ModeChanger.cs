using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private Publisher publisher;
    [SerializeField] private Mode mode;
    [SerializeField] private BoolObject hasTablet;
    [SerializeField] private AudioSource open, close;
    private bool isActive;

    private void Start()
    {
      publisher.NotifySubscribers();
    }

    private void Update()
    {
      if(hasTablet.value)
      {
        ChangeMode();
      }
    }

    private void ChangeMode()
    {
      if(Input.GetButtonDown("Open Tablet"))
      {
        if(mode.mode3D)
        {
          open.Play();
          isActive = true;
          mode.mode3D = false;
          publisher.NotifySubscribers();
        } else if(!mode.mode3D && isActive)
        {
          close.Play();
          isActive = false;
          mode.mode3D = true;
          publisher.NotifySubscribers();
        }
      }
    }

}
