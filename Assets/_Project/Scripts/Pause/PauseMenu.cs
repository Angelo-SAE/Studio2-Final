using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Mode mode;

    public void OnNotify()
    {
      OpenCloseMenu();
    }

    private void OpenCloseMenu()
    {
      if(mode.mode3D)
      {
        menu.SetActive(false);
      } else {
        menu.SetActive(true);
      }
    }
}
