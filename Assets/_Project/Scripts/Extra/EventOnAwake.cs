using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAwake : MonoBehaviour
{
    [SerializeField] private UnityEvent OnAwakeEvent;
    
    private void Awake()
    {
      OnAwakeEvent.Invoke();
    }
}
