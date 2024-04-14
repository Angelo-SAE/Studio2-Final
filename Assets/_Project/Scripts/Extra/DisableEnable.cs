using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnable : MonoBehaviour
{
    public void OnNotify()
    {
      if(gameObject.active)
      {
        gameObject.SetActive(false);
      } else {
        gameObject.SetActive(true);
      }
    }
}
