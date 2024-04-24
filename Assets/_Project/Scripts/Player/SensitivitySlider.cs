using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private FloatObject sensitivity;

    private void Awake()
    {
      sensitivitySlider.value = sensitivity.value;
    }

    public void OnNotify()
    {
      ChangeSensitivity();
    }

    private void ChangeSensitivity()
    {
      sensitivity.value = sensitivitySlider.value * 0.02f;
    }
}
