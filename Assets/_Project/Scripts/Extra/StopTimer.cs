using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopTimer : MonoBehaviour
{
    [SerializeField] private FloatObject time;
    [SerializeField] private TMP_Text timerText;
    private int hours, minutes, seconds;

    private void Awake()
    {
      CalculateTime();
      timerText.text =  hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
    }

    private void CalculateTime()
    {
      while(true)
      {
        if(time.value > 3600)
        {
          hours += (int)1;
          time.value -= 3600;
        }
        if(time.value < 3600 && time.value > 60)
        {
          minutes += (int)1;
          time.value -= 60;
        }
        if(time.value < 60f)
        {
          seconds = (int)time.value;
          return;
        }
      }
    }
}
