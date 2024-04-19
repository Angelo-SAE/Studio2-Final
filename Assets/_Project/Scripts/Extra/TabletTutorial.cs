using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTutorial : MonoBehaviour
{
    private void Update()
    {
      if(Input.GetButtonDown("Open Tablet"))
      {
        gameObject.SetActive(false);
      }
    }
}
