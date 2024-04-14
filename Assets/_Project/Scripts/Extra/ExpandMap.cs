using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandMap : MonoBehaviour
{
    [SerializeField] private Current2D currentCamera;
    
    public void OnNotify()
    {
      currentCamera.cameraNumber++;
    }
}
