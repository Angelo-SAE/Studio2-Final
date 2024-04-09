using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ManageVolume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audio;
    [SerializeField] private FloatObject volume;
    [SerializeField] private string audioMixer;

    private void Awake()
    {
      volumeSlider.value = volume.value;
    }

    public void OnNotify()
    {
      volume.value = volumeSlider.value;
      audio.SetFloat(audioMixer, volumeSlider.value);
    }
}
