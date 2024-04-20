using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ManageVolume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private FloatObject volume;
    [SerializeField] private string audioMixerName;

    public void SetDefaultVolume()
    {
      volumeSlider.value = volume.value;
      audioMixer.SetFloat(audioMixerName, volumeSlider.value);
    }

    public void OnNotify()
    {
      if(volumeSlider.value <= -20f)
      {
        volume.value = -80f;
      } else {
        volume.value = volumeSlider.value;
      }
      audioMixer.SetFloat(audioMixerName, volume.value);
    }
}
