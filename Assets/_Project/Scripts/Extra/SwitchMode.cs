using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    [SerializeField] private Mode mode;

    public void OnNotify()
    {
      if(mode.mode3D)
      {
        mode.mode3D = false;
      } else {
        mode.mode3D = true;
      }
    }
}
