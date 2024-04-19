using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Candle : MonoBehaviour
{
    [SerializeField] private UnityEvent lightCandle;

    public void OnNotify()
    {
      lightCandle.Invoke();
    }
}
