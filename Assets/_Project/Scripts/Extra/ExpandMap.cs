using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpandMap : MonoBehaviour
{
    [SerializeField] private Current2D currentCamera;
    [SerializeField] private UnityEvent onExpansion;

    public void OnNotify()
    {
      currentCamera.cameraNumber++;
      onExpansion.Invoke();
    }
}
