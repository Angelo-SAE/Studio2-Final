using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapExpansion : Interactable
{
    [SerializeField] private Current2D currentCamera;

    public override void Interact()
    {
      currentCamera.cameraNumber++;
      Destroy(gameObject);
    }
}
