using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour, IObserver
{
    [SerializeField] private ModeChanger observable;
    [SerializeField] private Current2D current2D;
    [SerializeField] private GameObject camera3D;
    [SerializeField] private GameObject[] cameras2D;
    private bool needChange, mode3D;

    private void Awake()
    {
      AddSelfToObservable();
    }

    public void AddSelfToObservable()
    {
      observable.AddObserver(this);
    }

    public void PerformObserableAction(bool recievedVariable)
    {
      mode3D = recievedVariable;
      ChangeCamera();
    }

    private void ChangeCamera()
    {
      if(mode3D)
      {
        camera3D.SetActive(true);
        cameras2D[current2D.cameraNumber].SetActive(false);
        LockCursor();
      } else if(!mode3D)
      {
        cameras2D[current2D.cameraNumber].SetActive(true);
        camera3D.SetActive(false);
        UnlockCursor();
      }
    }

    private void LockCursor()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }

    private void UnlockCursor()
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
}
