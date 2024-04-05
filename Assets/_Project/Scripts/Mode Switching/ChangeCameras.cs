using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    [SerializeField] private Current2D current2D;
    [SerializeField] private GameObject camera3D;
    [SerializeField] private GameObject[] cameras2D;
    [SerializeField] private Mode mode;

    public void OnNotify()
    {
      ChangeCamera();
    }

    private void ChangeCamera()
    {
      if(mode.mode3D)
      {
        camera3D.SetActive(true);
        cameras2D[current2D.cameraNumber].SetActive(false);
      } else if(!mode.mode3D)
      {
        cameras2D[current2D.cameraNumber].SetActive(true);
        camera3D.SetActive(false);
      }
    }


}
