using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultScriptableObjects : MonoBehaviour
{
    [SerializeField] private Current2D currentCamera;
    [SerializeField] private Mode mode;
    [SerializeField] private BoolObject hasTablet;
    [SerializeField] private BoolObject generatorOne;
    [SerializeField] private BoolObject isSwapping;

    private void Awake()
    {
      currentCamera.cameraNumber = 0;
      mode.mode3D = true;
      hasTablet.value = false;
      generatorOne.value = false;
      isSwapping.value = true;
    }
}
