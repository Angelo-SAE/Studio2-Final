using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    void Update()
    {
      if(Input.GetButtonDown("Close Window"))
      {
        gameObject.SetActive(false);
      }
    }
}
