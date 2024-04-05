using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockUnlockCursor : MonoBehaviour
{

    [SerializeField] private Mode mode;

    public void OnNotify()
    {
      LockUnlock();
    }

    private void LockUnlock()
    {
      if(mode.mode3D)
      {
        LockCursor();
      } else if(!mode.mode3D)
      {
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
