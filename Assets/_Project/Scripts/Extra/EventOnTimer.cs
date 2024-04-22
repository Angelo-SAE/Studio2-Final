using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTimer : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private UnityEvent afterTime;

    private IEnumerator Start()
    {
      yield return new WaitForSeconds(waitTime);
      afterTime.Invoke();
    }
}
