using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onPickup, onDrop;

    private bool canDrag;
    public bool CanDrag
    {
      get => canDrag;
      set => canDrag = value;
    }

    private void Start()
    {
      canDrag = true;
    }

    public void OnPickup()
    {
      onPickup.Invoke();
    }

    public void OnDrop()
    {
      onDrop.Invoke();
    }
}
