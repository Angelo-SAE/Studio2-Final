using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCheats : MonoBehaviour
{
    [SerializeField] private GameObject devPanel;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.M) && devPanel.activeSelf)
      {
        devPanel.SetActive(false);
      } else if(Input.GetKeyDown(KeyCode.M))
      {
        devPanel.SetActive(true);
      }
    }
}
