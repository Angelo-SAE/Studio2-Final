using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultScriptableObjects : MonoBehaviour
{
    [SerializeField] private Current2D currentCamera;

    private void Awake()
    {
      currentCamera.cameraNumber = 0;
    }
}
