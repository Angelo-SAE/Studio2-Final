using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeToTimer : MonoBehaviour
{
    [SerializeField] private FloatObject timer;
    
    private void Awake()
    {
      timer.value = 0;
    }

    private void Update()
    {
      timer.value += Time.deltaTime;
    }
}
