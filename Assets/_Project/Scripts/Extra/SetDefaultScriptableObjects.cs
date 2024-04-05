using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultScriptableObjects : MonoBehaviour
{
    [SerializeField] private Current2D currentCamera;
    [SerializeField] private Mode mode;

    private void Awake()
    {
      currentCamera.cameraNumber = 0;
      mode.mode3D = true;
    }
}
