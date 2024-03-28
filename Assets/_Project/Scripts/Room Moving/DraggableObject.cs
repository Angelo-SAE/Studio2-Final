using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool canDrag;
    public bool CanDrag
    {
      get => canDrag;
    }

    private void Start()
    {
      canDrag = true;
    }
}
